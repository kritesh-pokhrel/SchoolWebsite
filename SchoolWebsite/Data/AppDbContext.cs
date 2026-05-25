using Microsoft.EntityFrameworkCore;
using SchoolWebsite.Models;

namespace SchoolWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContentItem> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContentItem>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Slug).IsUnique();
                b.Property(x => x.Slug).IsRequired().HasMaxLength(200);
                b.Property(x => x.Title).HasMaxLength(500);
                b.Property(x => x.BodyHtml).HasColumnType("TEXT");
                b.Property(x => x.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
