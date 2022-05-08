using FiveMinuteMindfulness.Data;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness;

public class DataHelper
{
    public static void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        using var context = serviceScope
            .ServiceProvider.GetService<FiveMinutesContext>();

        if (context == null)
        {
            throw new ApplicationException("Problem in services. No db context.");
        }

        if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
        {
            context.Database.Migrate();
        }

        if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
        {
            // TODO
        }

        if (configuration.GetValue<bool>("DataInitialization:SeedData"))
        {
            // TODO
        }
    }
}