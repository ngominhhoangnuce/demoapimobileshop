using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IShopResponsitory
    {
        IEnumerable<Shop> GetAllProducts();
    }
}
