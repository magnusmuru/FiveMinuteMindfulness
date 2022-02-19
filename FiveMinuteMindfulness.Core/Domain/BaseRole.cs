using FiveMinuteMindfulness.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FiveMinuteMindfulness.Core.Domain;

public class BaseRole : BaseRole<Guid>, IEntityWithId
{
}

public class BaseRole<TKey> : IdentityRole<TKey>, IEntityWithId<TKey> where TKey : IEquatable<TKey>
{
}