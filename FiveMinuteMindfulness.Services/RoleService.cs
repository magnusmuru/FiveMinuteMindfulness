using AutoMapper;
using FiveMinuteMindfulness.Core.Dto;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using FiveMinuteMindfulness.Services.Domain;
using FiveMinuteMindfulness.Services.Interfaces;

namespace FiveMinuteMindfulness.Services;

public class RoleService : ServiceBase<Role, RoleDto>, IRoleService
{
    public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Role entity, RoleDto entityDto)
    {
        throw new NotImplementedException();
    }
}