using AutoMapper;

namespace FiveMinuteMindfulness.Core.Profiles;

public abstract class BaseProfile<TEntity, TEntityDto> : Profile
{
    public BaseProfile()
    {
        CreateMap<TEntity, TEntityDto>().ReverseMap();
    }
}