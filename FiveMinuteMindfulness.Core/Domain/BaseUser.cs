using FiveMinuteMindfulness.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FiveMinuteMindfulness.Core.Domain;

public class BaseUser : BaseUser<Guid>, IEntityWithId
{
}

public class BaseUser<TKey> : IdentityUser<TKey>, IEntityWithId<TKey> where TKey : IEquatable<TKey>
{
}