using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Proyecto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 #region add SERILOG
                 .UseSerilog((context, config) =>
                 {
                     config.WriteTo.Console();
                     config.WriteTo.File("Logs.txt", Serilog.Events.LogEventLevel.Information);
                     config.WriteTo.ApplicationInsights(new TelemetryClient()
                     {
                         InstrumentationKey = "f818890a-ae5f-4b85-a779-b98e35ebb652",
                     }, TelemetryConverter.Events);
                 })
                #endregion
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
