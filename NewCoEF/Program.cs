using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NewCoEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging(log=>
            {
                //log.AddTraceSource("NewCoSwitch"); // Eventi con System.Diagnostics.Trace
                log.AddLog4Net(); //Eventi gestiti con pacchetto di terze parti, per es. Log4Net
            });
    }
}
