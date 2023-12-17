using Serilog;

namespace CTD.Extensions
{
    public static class StartupExtensions
    {
        public static void AddSerilogService(this IServiceCollection services, IConfiguration config)
        {
            var strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/ctd-serilog-file.txt");
            services.AddSerilog();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.File(strPath, rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();
        }
    }
}
