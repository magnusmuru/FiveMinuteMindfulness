using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data;
using FiveMinuteMindfulness.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext and set Migration assembly to .Data project
builder.Services.AddDbContext<FiveMinutesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FiveMinutes"),
        x => x.MigrationsAssembly("FiveMinuteMindfulness.Data")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, Role>(options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddDefaultUI()
    .AddEntityFrameworkStores<FiveMinutesContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Initialize config model/provider
// builder.Services.Configure<FiveMinutesConfig>(builder.Configuration.GetSection("FiveMinutesConfig"));
// builder.Services.AddSingleton(builder.Configuration.GetSection("FiveMinutesConfig").Get<FiveMinutesConfig>());

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Wire Serilog into builder
builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

// Inject self used services
builder.Services.AddDataServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();