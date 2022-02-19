using FiveMinuteMindfulness.Core.Domain.Interfaces;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class, IEntityWithId
{
    private readonly DbContext _context;

    protected RepositoryBase(DbContext context)
    {
        _context = context;
    }

    private DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public virtual async Task Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        await Task.Run(() => DbSet.Update(entity));
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(TEntity entity)
    {
        await Task.Run(() => DbSet.Remove(entity));
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> Find(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IList<TEntity>> FindAll()
    {
        return await DbSet.ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}