using AnalyticAlways.AngularTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnalyticAlways.AngularTest.Infrastructure
{
    public class AngularTestContext : DbContext
    {
        public AngularTestContext(DbContextOptions<AngularTestContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetArticleConfiguration(modelBuilder);
            SetStoreConfiguration(modelBuilder);
        }

        private void SetArticleConfiguration(ModelBuilder modelBuilder)
        {
            var article = modelBuilder.Entity<Article>();

            article
                .ToTable("Articles");

            article
                .HasKey(a => a.Id);

            article
                .Property(a => a.Price)
                .IsRequired();

            article
                .Property(a => a.Description)
                .HasMaxLength(200)
                .IsRequired();
        }

        private void SetStoreConfiguration(ModelBuilder modelBuilder)
        {
            var store = modelBuilder.Entity<Store>();

            store
                .ToTable("Stores");

            store
                .HasKey(s => s.Id);

            store
                .Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            store
               .Property(s => s.City)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}
