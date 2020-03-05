using ClickToBuy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Database
{
    public class CTBContext : DbContext 
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c=>c.Name).IsUnique();
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
