


using Microsoft.EntityFrameworkCore;

namespace ApiMobileShop.Data
{
    public class MobileContext:DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options) { }

        #region DbSet
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShopCart>(entity => entity.HasMany(x => x.Product).WithOne(x => x.ShopCart).HasForeignKey(x => x.ShopProductID));
        }

    }
}
