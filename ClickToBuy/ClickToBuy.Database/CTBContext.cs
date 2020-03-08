using ClickToBuy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Database
{
    public class CTBContext : DbContext 
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<CloseType> CloseTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(b=>b.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<Gender>().HasIndex(g=>g.Name).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c=> new { c.Email, c.Name }).IsUnique();
            modelBuilder.Entity<Condition>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<CloseType>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-HHA0TOP; 
                                    Initial Catalog = ClickToBuy; 
                                    Integrated Security = SSPI;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
