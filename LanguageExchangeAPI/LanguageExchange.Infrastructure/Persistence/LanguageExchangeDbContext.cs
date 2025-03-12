using LanguageExchange.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Persistence
{
    public class LanguageExchangeDbContext : DbContext
    {
        public LanguageExchangeDbContext(DbContextOptions<LanguageExchangeDbContext> options) : base(options)
        {
        }        
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserAdditionalInformation> UserAdditionalInformations { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<StudyMaterial> StudyMaterials { get; set; }        
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<UserAddress>().HasKey(u => u.Id);
            builder.Entity<UserAdditionalInformation>().HasKey(u => u.Id);
            builder.Entity<PasswordResetToken>().HasKey(p => p.Id);
            builder.Entity<Notification>().HasKey(n=> n.Id);

            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentTransaction>().HasKey(p => p.Id);

            builder.Entity<Subscription>().HasKey(s => s.Id);
            builder.Entity<SubscriptionPlan>().HasKey(s => s.Id);

            builder.Entity<StudyMaterial>().HasKey(s => s.Id);
            builder.Entity<Language>().HasKey(l => l.Id);

            builder.Entity<Subscription>()
                .HasOne(s => s.User)
                 .WithMany(u => u.Subscriptions)
                 .HasForeignKey(s => s.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscription>()
                .HasOne(s => s.SubscriptionPlan)
                 .WithMany(u => u.Subscriptions)
                 .HasForeignKey(s => s.SubscriptionPlanId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserAdditionalInformation>()
                .HasOne(a => a.User)
                .WithOne(u => u.UserAdditionalInformation)
                .HasForeignKey<UserAdditionalInformation>(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserAddress>()
                .HasOne(ua => ua.User)
                .WithOne(u => u.UserAddress)
                .HasForeignKey<UserAddress>(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PaymentMethod>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PasswordResetToken>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.PasswordResetTokens)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PaymentTransaction>()
                .HasOne(pt => pt.User)
                .WithMany(u => u.PaymentTransactions)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PaymentTransaction>()
                .HasOne(pt => pt.Subscription)
                .WithMany(s => s.PaymentTransactions)
                .HasForeignKey(pt => pt.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);
                  
        }
    }
}
