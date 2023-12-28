using CTD.BussinessOperations.Data;
using CTD.BussinessOperations.Models.CustomModels;
using CTD.BussinessOperations.Services;
using CTD.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration["Database:CTDStr"];
var autoMigrate = Convert.ToBoolean(builder.Configuration["Database:AutoMigrate"]);

// Add services to the container.
var clientEmailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<ClientEmailConfiguration>();
builder.Services.AddSingleton(clientEmailConfig);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailSendService, EmailSendService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();
builder.Services.AddDbContext<CTDContext>((p, options) =>
{
    options.UseSqlServer(connStr);
    if (!builder.Environment.IsProduction())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});
builder.Services.AddSerilogService(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

if (autoMigrate)
{
    using var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
    scope?.ServiceProvider?.GetRequiredService<CTDContext>()?.Database?.Migrate();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
