using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewCoEF.Security.Data;
using NewCoEF.Security.Models;
using System;

namespace NewCoEF.Security
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<SecurityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; //Conferma via mail dopo la registrazione

                //Personalizzazione regole standard per la password
                options.Password.RequiredLength = 8; //Lunghezza minima
                options.Password.RequireDigit = true; //Numeri
                options.Password.RequireNonAlphanumeric = true; //Caratteri non alfanumerici (numeri e punteggiatura)
                options.Password.RequireUppercase = true; //Caratteri in maiuscolo
                options.Password.RequiredUniqueChars = 2; //Numero di caratteri univoci
                options.Password.RequireLowercase = false; //Caratteri in minuscolo

                //Protezione dal Brute Force
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(8); //Tempo di attesa dopo l'ultimo tentativo fallito
                options.Lockout.MaxFailedAccessAttempts = 3; //Numero dei tentativi di autenticazione

            })
            .AddRoles<IdentityRole>() //Supporto al RoleManager<IdentityRole>
            .AddEntityFrameworkStores<ApplicationDbContext>()
            //Aggiunge i generatori di token predefiniti utilizzati per generare i token per le operazioni
            //di reimpostazione della password, modifica dell'e-mail e del numero di telefono e 
            //per la generazione di token per l'autenticazione a due fattori.
            .AddDefaultTokenProviders();

            //Sign-out remoto (o meglio sign-out "automatico")
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                //Tempo di validità del cookie con SecurityStamp
                options.ValidationInterval = TimeSpan.FromMinutes(1);
            });

            

            //Gestione policy
            //services.AddScoped<IUserClaimsPrincipalFactory<SecurityUser>, SecurityClaimsPrincipalFactory>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            #region gestione policy
            //List<string> claimsForAdmin = new List<string>();
            //claimsForAdmin.Add("admin");
            //claimsForAdmin.Add("director");

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim(JwtClaimTypes.Role, claimsForAdmin));
            //});
            #endregion

            #region Google Auth

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
