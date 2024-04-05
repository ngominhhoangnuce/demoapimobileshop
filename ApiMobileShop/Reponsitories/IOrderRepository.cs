using ApiMobileShop.Data;
using ApiMobileShop.DTO;

namespace ApiMobileShop.Reponsitories
{
    public interface IOrderRepository
    {
        Task<(string orderId, string error)> CreateOrder(string userId, Order order);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<string> DeleteOrderById(string orderId, string userId);
    }
}

