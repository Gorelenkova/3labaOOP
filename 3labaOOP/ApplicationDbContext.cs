using _3labaOOP.Models;
using Microsoft.EntityFrameworkCore;

namespace _3labaOOP
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(x => x.Cart).WithOne(x => x.User).HasForeignKey<Cart>(x => x.UserId);

            modelBuilder.Entity<CartProduct>()
                 .HasOne(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(x => x.Cart).WithMany(x => x.Products).HasForeignKey(x => x.CartId);


            base.OnModelCreating(modelBuilder);
        }


    }
}
