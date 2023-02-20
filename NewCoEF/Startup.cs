using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewCoEF.Hubs;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using NewCoEF.Resources;

namespace NewCoEF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<NewCoEFDbContext>(o =>
            {
                //o.UseLazyLoadingProxies();
                var connectionString = Configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
            });

            //Versioning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                //config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            //Inizializzazione del servizio Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Documentazione per la manipolazione dei dati di NewCoEF",
                    Description = "Tool di supporto agli sviluppatori per poter utilizzare le Web API",
                    TermsOfService = null,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "My Name",
                        Email = "mymail@mail.com",
                        Url = new Uri("https://myurl.com")
                    }
                });

                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "Documentazione per la manipolazione dei dati di NewCoEF V2",
                    Description = "Tool di supporto agli sviluppatori per poter utilizzare le Web API V2, <h2>in questa versione sono considerati solo i portatili!!!</h2>",
                    TermsOfService = null,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "My Name V2",
                        Email = "mymail__V2__@mail.com",
                        Url = new Uri("https://myurl.com")
                    }
                });

                c.EnableAnnotations();

                //Gestione decumentazione aggiuntiva su XML
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSignalR()
                .AddJsonProtocol(options =>
                {
                    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                });

            #region Localization

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("it"),
                    new CultureInfo("en"),
                    new CultureInfo("fr")
                };
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.FallBackToParentUICultures = true;
                options.DefaultRequestCulture = new RequestCulture("en");
            });

            //Identifica il percorso della cartella delle risorse
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //Indica che le risorse delle view saranno gestite con il suffisso della localizzazione
            //attivando anche la logica sulle DataAnnotation
            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddMvcLocalization()
                    .AddDataAnnotationsLocalization();
                    //.AddDataAnnotationsLocalization(options =>
                    //{
                    //    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    //      {
                    //          return factory.Create(typeof(SharedResource));
                    //      };
                    //});

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider, ILoggerFactory loggerFactory)
        {
            app.UseRequestLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");

                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = Text.Html;

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature.Path.Contains("/PersonalData/"))
                        {
                            context.Response.Redirect("/PersonalData/Home/Error");
                        }
                        else if (exceptionHandlerPathFeature.Path.Contains("/Sales/"))
                        {
                            context.Response.Redirect("/Sales/Home/Error");
                        }
                        else
                            context.Response.Redirect("/Home/Error");
                    });
                });

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region CodePages

            //app.UseStatusCodePages();
            //app.UseStatusCodePagesWithRedirects("");
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }

                //Personalizzazione dell'endpoint
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewCoEF API v1.0");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<LoadingHub>("/loadingHub", options =>
                {
                    options.Transports =
                        HttpTransportType.WebSockets |
                        HttpTransportType.LongPolling;
                });
            });
        }
    }
}
