using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class SectionService : ServiceBase<Section, SectionDto>, ISectionService
{
    public SectionService(ISectionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Section entity, SectionDto entityDto)
    {
        throw new NotImplementedException();
    }
}