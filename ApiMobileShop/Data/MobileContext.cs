


using Microsoft.EntityFrameworkCore;

namespace ApiMobileShop.Data
{
    public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options) { }

        #region DbSet
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopCart> ShopCarts { get; set; }
        public virtual DbSet<ShopProduct> ShopProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShopCart>(entity => entity.HasMany(x => x.Product).WithOne(x => x.ShopCart).HasForeignKey(x => x.ShopProductID));
        }

    }
}
