using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IShopProductResponsitory
    {
        ShopProduct GetProductById(int ShopProductID);
    }
}
