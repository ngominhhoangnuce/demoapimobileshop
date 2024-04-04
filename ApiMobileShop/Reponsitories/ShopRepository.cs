using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public class ShopRepository : IShopRepository
    {
        private readonly MobileContext _shopmodel;

        public ShopRepository(MobileContext shopmodel)
        {
            _shopmodel = shopmodel;
        }
        public IEnumerable<Shop> GetAllProducts()
        {
            return _shopmodel.Shops.ToList();
        }

    }
}
