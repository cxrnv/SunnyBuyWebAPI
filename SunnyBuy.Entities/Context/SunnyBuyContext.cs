using Microsoft.EntityFrameworkCore;

namespace SunnyBuy.Entities.Context
{
    public class SunnyBuyContext : DbContext
    {
        public SunnyBuyContext(DbContextOptions<SunnyBuyContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
    }
}