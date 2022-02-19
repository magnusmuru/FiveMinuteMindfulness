using FiveMinuteMindfulness.Core.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiveMinuteMindfulness.Data.Configurations;

public class SectionConfiguration: IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
    }
}