using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Application;

public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
{
    private readonly FiveMinutesContext _context;


    public async Task<List<Notification>> FindNotificationsWithUsers()
    {
        return await DbSet.Include(x => x.User).ToListAsync();
    }

    public NotificationRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}