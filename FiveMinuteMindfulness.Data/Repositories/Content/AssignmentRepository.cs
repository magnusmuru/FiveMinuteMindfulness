using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class AssignmentRepository : RepositoryBase<Assignment>, IAssignmentRepository
{
    private readonly FiveMinutesContext _context;

    public AssignmentRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}