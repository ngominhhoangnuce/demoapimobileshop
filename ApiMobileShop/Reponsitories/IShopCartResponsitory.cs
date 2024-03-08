using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IShopCartResponsitory
    {
        List<ShopCart> GetCartItems();
        void AddToCart(ShopCart ShopCart);
        void UpdateCartItem(ShopCart ShopCart);
        void RemoveCart(int ShopCartID);
    }
}
