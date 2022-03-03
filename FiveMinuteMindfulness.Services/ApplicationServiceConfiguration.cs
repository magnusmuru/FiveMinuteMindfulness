using FiveMinuteMindfulness.Services.Application;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Content;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiveMinuteMindfulness.Services;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJournalService, JournalService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IThemeService, ThemeService>();

        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IChapterService, ChapterService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<ITranscriptionService, TranscriptionService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}