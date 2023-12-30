using CTD.BussinessOperations.Data;
using CTD.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var autoMigrate = Convert.ToBoolean(builder.Configuration["Database:AutoMigrate"]);

builder.Services.AddEmailConfigurationService(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddEmailServices();
builder.Services.AddApplicationServices();
builder.Services.AddDbContextServices(builder);
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
