using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

public interface IAssignmentRepository : IRepositoryBase<Assignment>
{
    Task<List<Assignment>> FindAssignmentsWithCategoriesAndSections();
}