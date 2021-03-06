using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

public interface ISectionRepository : IRepositoryBase<Section>
{
    Task<List<Section>> FindSectionsWithAssignments();
}