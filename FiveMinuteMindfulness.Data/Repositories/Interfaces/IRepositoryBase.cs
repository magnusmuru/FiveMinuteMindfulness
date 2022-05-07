using FiveMinuteMindfulness.Core.Domain.Interfaces;

namespace FiveMinuteMindfulness.Data.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> : IDisposable
    where TEntity : class, IEntityWithId
{
    Task Add(TEntity entity);

    Task Update(TEntity entity);

    Task Remove(TEntity entity);

    Task<TEntity?> Find(Guid id);

    Task<IList<TEntity>> FindAll();
}