using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<PaymentItem>? PaymentItems { get; set; }
        public DbSet<Sku>? Skus { get; set; }
        public DbSet<UserItemReference>? UserItemReferences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<UserItemReference>()
                .HasOne(c => c.Commiter)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserItemReference>()
                .HasOne(r => r.Recepient)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
