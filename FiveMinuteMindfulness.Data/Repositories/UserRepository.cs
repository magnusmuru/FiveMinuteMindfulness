using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly FiveMinutesContext _context;

    public UserRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}