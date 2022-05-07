using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class AssignmentRepository : RepositoryBase<Assignment>, IAssignmentRepository
{
    private readonly FiveMinutesContext _context;

    public AssignmentRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Assignment>> FindAssignmentsWithCategoriesAndSections()
    {
        return await DbSet.Include(x => x.Category).Include(x => x.Section).ToListAsync();
    }
}