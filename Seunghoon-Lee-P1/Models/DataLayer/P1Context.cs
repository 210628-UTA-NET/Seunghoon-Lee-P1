using Microsoft.EntityFrameworkCore;
using Seunghoon_Lee_P1.Models.DataLayer.SeedData;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer
{
    public class P1Context : DbContext
    {
        public P1Context(DbContextOptions<P1Context> p_options)
            : base(p_options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set primary keys
            modelBuilder.Entity<Inventory>().HasKey(i => new { i.StoreId, i.ProductId });

            //Set foreign keys
            modelBuilder.Entity<Inventory>().HasOne(i => i.Store)
                .WithMany(s => s.Inventories)
                .HasForeignKey(i => i.StoreId);
            modelBuilder.Entity<Inventory>().HasOne(i => i.Product)
                .WithMany(p => p.Inventories)
                .HasForeignKey(i => i.ProductId);

            //Remove cascading delete
            modelBuilder.Entity<Product>().HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Store>().HasOne(s => s.State)
                .WithMany(s => s.Stores)
                .OnDelete(DeleteBehavior.Restrict);

            //Seed Data
            modelBuilder.ApplyConfiguration(new SeedStates());
            modelBuilder.ApplyConfiguration(new SeedStores());
            modelBuilder.ApplyConfiguration(new SeedBrands());
            modelBuilder.ApplyConfiguration(new SeedCategories());
            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedInventories());
        }
    }
}
