using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
