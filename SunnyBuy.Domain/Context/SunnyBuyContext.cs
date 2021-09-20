using Microsoft.EntityFrameworkCore;
using SunnyBuy.Domain.Entities;

namespace SunnyBuy.Domain
{
    public class SunnyBuyContext : DbContext
    {
        public SunnyBuyContext(DbContextOptions<SunnyBuyContext> options) : base(options) { }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Purchase_Cart> Purchase_Cart { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PersonType> PersonType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase_Cart>().HasKey(pc => new { pc.PurchaseId, pc.CartId });

            modelBuilder.Entity<Purchase_Cart>()
                .HasOne<Cart>(pc => pc.Cart)
                .WithMany(pc => pc.Purchase_Carts)
                .HasForeignKey(pc => pc.CartId);


            modelBuilder.Entity<Purchase_Cart>()
                .HasOne<Purchase>(pc => pc.Purchase)
                .WithMany(pc => pc.Purchase_Carts)
                .HasForeignKey(pc => pc.PurchaseId);
        }
    }
}