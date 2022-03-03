using AutoMapper;
using FiveMinuteMindfulness.Core.Dto;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using FiveMinuteMindfulness.Services.Domain;
using FiveMinuteMindfulness.Services.Interfaces;

namespace FiveMinuteMindfulness.Services;

public class UserService : ServiceBase<User, UserDto>, IUserService
{
    public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(User entity, UserDto entityDto)
    {
        throw new NotImplementedException();
    }
}