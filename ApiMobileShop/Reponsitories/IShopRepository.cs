using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IShopRepository
    {
        IEnumerable<Shop> GetAllProducts();
    }
}
