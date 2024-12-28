using E_Commerce_Final.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Commerce_Final.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options) :base(options){ }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(c => c.customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(x => x.CustomerIDD)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.order)
                .WithMany(i => i.Items)
                .HasForeignKey(x => x.OrderIDD)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
               .HasOne(p=>p.product)
               .WithMany(i => i.Items)
               .HasForeignKey(x => x.ProductIDD)
               .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
