using ApiMobileShop.DTO;

namespace ApiMobileShop.Reponsitories
{
    public interface IOrderRepository
    {
        Task<(OrderDTO order, string error)> CreateOrder(string userId);
        Task<(OrderDTO order, string error)> GetOrderById(string orderId, string userId);
        Task<IEnumerable<OrderDTO>> GetAllOrders(string userId);
        Task<string> DeleteOrderById(string orderId, string userId);
    }
}

