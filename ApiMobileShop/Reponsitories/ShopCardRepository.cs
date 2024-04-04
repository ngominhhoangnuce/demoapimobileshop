using ApiMobileShop.Data;
using ApiMobileShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMobileShop.Reponsitories
{
    public class ShopCardRepository : IShopCartRepository
    {
        private readonly MobileContext _shopcartResponsitory;

        public ShopCardRepository(MobileContext shopcart)
        {
            _shopcartResponsitory = shopcart;
        }

        public IEnumerable<ShopCart> GetAllCartItems()
        {
            return _shopcartResponsitory.ShopCarts.ToList();
        }   
        public ShopCart GetById(int ShopCartID)
        {
            return _shopcartResponsitory.ShopCarts.Find(ShopCartID);
        }
        public void Add(ShopCart item)
        {
            _shopcartResponsitory.ShopCarts.Add(item);
            _shopcartResponsitory.SaveChanges();
        }

        public void Update(ShopCart item)
        {
            _shopcartResponsitory.ShopCarts.Update(item);
            _shopcartResponsitory.SaveChanges();
        }

        public void Delete(ShopCart item)
        {
            _shopcartResponsitory.ShopCarts.Remove(item);
            _shopcartResponsitory.SaveChanges();
        }
    }
}
