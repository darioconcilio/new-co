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
            .ConfigureLogging(log =>
            {
                log.AddEventLog();
                log.AddEventSourceLogger();
                log.AddTraceSource("NewCoSwitch"); // Eventi con System.Diagnostics.Trace

                //https://logging.apache.org/log4net/release/config-examples.html
                //log.AddLog4Net(); //Eventi gestiti con pacchetto di terze parti, per es. Log4Net
            });
    }
}
