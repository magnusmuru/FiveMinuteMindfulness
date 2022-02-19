using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Content;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private readonly FiveMinutesContext _context;

    public CategoryRepository(FiveMinutesContext context) : base(context)
    {
        _context = context;
    }
}