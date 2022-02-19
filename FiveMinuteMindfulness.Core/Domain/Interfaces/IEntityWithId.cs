namespace FiveMinuteMindfulness.Core.Domain.Interfaces;

public interface IEntityWithId : IEntityWithId<Guid>
{
}

public interface IEntityWithId<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}