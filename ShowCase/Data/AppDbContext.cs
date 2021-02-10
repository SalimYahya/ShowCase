using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            // Configure User-Porduct relations
            modelBuilder
                .Entity<Product>()
                .HasOne(u => u.ApplicationUser)
                .WithMany(p => p.Products);

            // Invoice Entity
            modelBuilder
                .Entity<Invoice>()
                .HasOne(u => u.ApplicationUser)
                .WithMany(i => i.Invoices);

            modelBuilder
                .Entity<Invoice>()
                .Property("IsConfirmed").HasDefaultValue(false);

            modelBuilder
                .Entity<Invoice>()
                .Property("TotalItems").HasDefaultValue(0);

            modelBuilder
                .Entity<Invoice>()
                .Property("Vat").HasDefaultValue(0);

            modelBuilder
                .Entity<Invoice>()
                .Property("TotalExcludeVat").HasDefaultValue(0.00);

            modelBuilder
                .Entity<Invoice>()
                .Property("TotalIncludeVat").HasDefaultValue(0.00);

            // InvoiceProduct Entity
            modelBuilder
                .Entity<InvoiceProduct>()
                .HasKey(up => new {up.InvoiceId, up.ProductId });

        }

    }
}
