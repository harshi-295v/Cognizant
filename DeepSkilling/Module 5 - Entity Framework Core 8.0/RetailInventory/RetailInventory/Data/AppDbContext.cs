using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLEXPRESS;
                  Database=RetailInventoryDB;
                  Trusted_Connection=True;
                  TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetail>()
                .HasOne(pd => pd.Product)
                .WithOne(p => p.ProductDetail)
                .HasForeignKey<ProductDetail>(pd => pd.ProductId);
        }
    }
}