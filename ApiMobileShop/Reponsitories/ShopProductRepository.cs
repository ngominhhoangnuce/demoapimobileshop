using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public class ShopProductRepository : IShopProductRepository
    {
        private readonly MobileContext _shopproduct;

        public ShopProductRepository(MobileContext shopproduct)
        {
            _shopproduct = shopproduct;
        }

        public ShopProduct GetProductById(int ShopProductID)
        {
            return _shopproduct.ShopProducts.Find(ShopProductID);
        }
    }
}
