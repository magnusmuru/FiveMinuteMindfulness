using FiveMinuteMindfulness.Core.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiveMinuteMindfulness.Data.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasOne(chapter => chapter.Transcription)
            .WithOne(transcription => transcription.Chapter)
            .HasForeignKey<Chapter>(x => x.TranscriptionId)
            .IsRequired(false);
    }
}