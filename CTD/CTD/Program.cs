using CTD.BussinessOperations.Data;
using CTD.BussinessOperations.Models.CustomModels;
using CTD.BussinessOperations.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration["Database:CTDStr"];
var autoMigrate = Convert.ToBoolean(builder.Configuration["Database:AutoMigrate"]);

// Add services to the container.
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailSendService, EmailSendService>();
builder.Services.AddDbContext<CTDContext>((p, options) =>
{
    options.UseSqlServer(connStr);
    if (!builder.Environment.IsProduction())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});



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
