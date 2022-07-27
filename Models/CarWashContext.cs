using Microsoft.EntityFrameworkCore;

namespace OnDemandCarWashSystemAPI.Models
{
    public class CarWashContext : DbContext
    {
        public CarWashContext() { }
        public CarWashContext(DbContextOptions options) : base(options) { }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}