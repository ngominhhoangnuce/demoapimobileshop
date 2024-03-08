using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public class ShopProductResponsitory : IShopProductResponsitory
    {
        private readonly MobileContext _shopproduct;

        public ShopProductResponsitory(MobileContext shopproduct)
        {
            _shopproduct = shopproduct;
        }

        public ShopProduct GetProductById(int ShopProductID)
        {
            return _shopproduct.ShopProducts.Find(ShopProductID);
        }
    }
}
