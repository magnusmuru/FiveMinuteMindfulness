using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class NotificationService : ServiceBase<Notification, NotificationDto>, INotificationService
{
    private readonly INotificationRepository _repository;
    private readonly IMapper _mapper;

    public NotificationService(INotificationRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<NotificationDto>> FindNotificationsWithUsers()
    {
        var notifications = await _repository.FindNotificationsWithUsers();
        return _mapper.Map<List<NotificationDto>>(notifications);
    }

    protected override void UpdateEntityValues(Notification entity, NotificationDto entityDto)
    {
        entity.NotificationType = entityDto.NotificationType;
        entity.Content = entityDto.Content;
        entity.UserId = entityDto.UserId;
        entity.NotificationTime = entityDto.NotificationTime;
    }
}