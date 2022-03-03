using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class NotificationService: ServiceBase<Notification, NotificationDto>, INotificationService
{
    public NotificationService(INotificationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Notification entity, NotificationDto entityDto)
    {
        throw new NotImplementedException();
    }
}