using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Core.Models.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiveMinuteMindfulness.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Theme)
            .WithOne(theme => theme.User)
            .HasForeignKey<Theme>(x => x.UserId);
    }
}