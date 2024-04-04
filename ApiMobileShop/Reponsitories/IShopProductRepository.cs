using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IShopProductRepository
    {
        ShopProduct GetProductById(int ShopProductID);
    }
}
