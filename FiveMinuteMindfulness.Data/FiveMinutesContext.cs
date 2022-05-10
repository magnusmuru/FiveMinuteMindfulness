using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness.Data;

public class FiveMinutesContext : IdentityDbContext<User, Role, Guid>
{
    public FiveMinutesContext(DbContextOptions<FiveMinutesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ChapterConfiguration());
        builder.ApplyConfiguration(new ThemeConfiguration());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transcription> Transcriptions { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<Notification> Notifications { get; set; }
}