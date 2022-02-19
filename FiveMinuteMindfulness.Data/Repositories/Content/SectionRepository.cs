using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class SectionRepository : RepositoryBase<Section>, ISectionRepository
{
    private readonly FiveMinutesContext _context;

    public SectionRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}