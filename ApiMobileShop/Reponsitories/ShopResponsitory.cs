using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public class ShopResponsitory : IShopResponsitory
    {
        private readonly MobileContext _shopmodel;

        public ShopResponsitory(MobileContext shopmodel)
        {
            _shopmodel = shopmodel;
        }

        public List<Shop> GetAllProducts()
        {
            return _shopmodel.Shops.ToList();
        }
    }
}
