using FiveMinuteMindfulness.Data.Repositories;
using FiveMinuteMindfulness.Data.Repositories.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Data.Repositories.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiveMinuteMindfulness.Data;

public static class DataServiceConfiguration
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IJournalRepository, JournalRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IThemeRepository, ThemeRepository>();

        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<ITranscriptionRepository, TranscriptionRepository>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        return services;
    }
}