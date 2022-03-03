using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Application;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Data.Repositories.Application.Interfaces;
using FiveMinuteMindfulness.Services.Application.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Application;

public class JournalService : ServiceBase<Journal, JournalDto>, IJournalService
{
    public JournalService(IJournalRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Journal entity, JournalDto entityDto)
    {
        throw new NotImplementedException();
    }
}