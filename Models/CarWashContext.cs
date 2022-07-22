using Microsoft.EntityFrameworkCore;

namespace OnDemandCarWashSystemAPI.Models
{
    public class CarWashContext : DbContext
    {
        public CarWashContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}