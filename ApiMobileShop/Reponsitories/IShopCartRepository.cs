using ApiMobileShop.Data;


namespace ApiMobileShop.Reponsitories
{
    public interface IShopCartRepository
    {
        IEnumerable<ShopCart> GetAllCartItems();
        ShopCart GetById(int ShopCartID);
        void Add(ShopCart item);
        void Update(ShopCart item);
        void Delete(ShopCart item);
        //ShopCart CreateOrder(int ShopProductID, string Price, int Soluong);
    }
}
