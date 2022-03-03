using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    private readonly FiveMinutesContext _context;

    public RoleRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}