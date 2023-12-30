using CTD.BussinessOperations.Data;
using CTD.BussinessOperations.Models.CustomModels;
using CTD.BussinessOperations.Services;
using Serilog;
using Microsoft.EntityFrameworkCore;

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
        public static void AddEmailConfigurationService(this IServiceCollection services, IConfiguration config)
        {
            var clientEmailConfig = config
                                     .GetSection("EmailConfiguration")
                                     .Get<ClientEmailConfiguration>();
            services.AddSingleton(clientEmailConfig);
        }
        public static void AddEmailServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSendService, EmailSendService>();
            services.AddScoped<ISmtpService, SmtpService>();
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
        public static void AddDbContextServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connStr = builder.Configuration["Database:CTDStr"];
            services.AddDbContext<CTDContext>((p, options) =>
            {
                options.UseSqlServer(connStr);
                if (!builder.Environment.IsProduction())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });
        }
    }
}
