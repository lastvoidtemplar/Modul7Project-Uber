using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UberContext : DbContext
    {
        public UberContext() : base("Name=UberContext")
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverProfile> DriverProfile { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
