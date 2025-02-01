using LanguageExchange.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Persistence
{
    public class LanguageExchangeDbContext : DbContext
    {
        public LanguageExchangeDbContext(DbContextOptions<LanguageExchangeDbContext> options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Language>().HasKey(l => l.Id);
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Subscription>().HasKey(s => s.Id);
            builder.Entity<StudyMaterial>().HasKey(s => s.Id);


            builder.Entity<User>(u =>
            {
                u.HasOne(u => u.Subscription)
                 .WithMany(s => s.Users)
                 .HasForeignKey(u => u.IdSubscription)
                 .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Payment>(p =>
            {
                p.HasOne<User>(u => u.UserNavigation)
                 .WithMany()
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });           
        }
    }
}
