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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual  DbSet<DriverProfile> DriverProfiles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }
}
