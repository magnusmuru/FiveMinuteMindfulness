using System.Globalization;
using FiveMinuteMindfulness;
using FiveMinuteMindfulness.Core.Helpers;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data;
using FiveMinuteMindfulness.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext and set Migration assembly to .Data project
builder.Services.AddDbContext<FiveMinutesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FiveMinutes"),
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

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings        
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    // If the LoginPath isn't set, ASP.NET Core defaults         
    // the path to /Account/Login.        
    options.LoginPath = "/Identity/Account/Login";
    // If the AccessDeniedPath isn't set, ASP.NET Core defaults         
    // the path to /Account/AccessDenied.        
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.Configure<IdentityOptions>(options => {        
    // Password settings        
    options.Password.RequireDigit = false;        
    options.Password.RequiredLength = 1;        
    options.Password.RequireNonAlphanumeric = false;        
    options.Password.RequireUppercase = false;        
    options.Password.RequireLowercase = false;
    // User settings        
    options.User.RequireUniqueEmail = true;    
});

// I18N
var supportedCultures = builder.Configuration
    .GetSection("SupportedCultures")
    .GetChildren()
    .Select(x => new CultureInfo(x.Value))
    .ToArray();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // datetime and currency support
    options.SupportedCultures = supportedCultures;
    // UI translated strings
    options.SupportedUICultures = supportedCultures;
    // if nothing is found, use this
    options.DefaultRequestCulture =
        new RequestCulture(builder.Configuration["DefaultCulture"],
            builder.Configuration["DefaultCulture"]);

    options.SetDefaultCulture(builder.Configuration["DefaultCulture"]);

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        // Order is important, its in which order they will be evaluated
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});

builder.Services.AddControllersWithViews(
    options => { options.ModelBinderProviders.Insert(0, new CustomLanguageStringBinderProvider()); }
);

var app = builder.Build();

DataHelper.SetupAppData(app, app.Environment, app.Configuration);

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
app.UseRequestLocalization(options: app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value!);


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