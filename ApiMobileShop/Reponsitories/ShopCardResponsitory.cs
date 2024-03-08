using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public class ShopCardResponsitory : IShopCartResponsitory
    {
        private readonly MobileContext _shopcart;

        public ShopCardResponsitory(MobileContext shopcart)
        {
            _shopcart = shopcart;
        }

        public List<ShopCart> GetCartItems()
        {
            return _shopcart.ShopCarts.ToList();
        }

        public void AddToCart(ShopCart ShopCart)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa
            var existingItem = _shopcart.ShopCarts.FirstOrDefault(item => item.ShopCartID == ShopCart.ShopCartID);

            if (existingItem != null)
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng
                existingItem.Soluong += ShopCart.Soluong;
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm mới vào giỏ hàng
                _shopcart.ShopCarts.Add(ShopCart);
            }

            _shopcart.SaveChanges();
        }

        public void UpdateCartItem(ShopCart ShopCart)
        {
            var existingItem = _shopcart.ShopCarts.Find(ShopCart.ShopCartID);

            if (existingItem != null)
            {
                existingItem.Soluong = ShopCart.Soluong;
                _shopcart.SaveChanges();
            }
        }

        public void RemoveCart(int ShopCartID)
        {
            var ShopCart = _shopcart.ShopCarts.Find(ShopCartID);

            if (ShopCart != null)
            {
                _shopcart.ShopCarts.Remove(ShopCart);
                _shopcart.SaveChanges();
            }
        }
    }
}
