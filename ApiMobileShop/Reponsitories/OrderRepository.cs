using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApiMobileShop.Data;
using ApiMobileShop.DTO;
using ApiMobileShop.Reponsitories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MobileContext _mobilecontext;

        public OrderRepository(MobileContext MbContext)
        {
            _mobilecontext = MbContext;
        }
        public async Task<(string orderId, string error)> CreateOrder(string userId, Order order)
        {
            try
            {
                // Gán userId cho đơn hàng
                order.UserId = userId;

                // Tạo một id mới cho đơn hàng
                order.OrderId = Guid.NewGuid().ToString();

                // Gán ngày hiện tại cho trường CreateDay của đơn hàng
                order.CreateDay = DateTime.Now;

                // Thêm đơn hàng mới vào DbContext
                _mobilecontext.Orders.Add(order);

                // Lưu thay đổi vào cơ sở dữ liệu
                await _mobilecontext.SaveChangesAsync();

                // Trả về id của đơn hàng mới và không có lỗi
                return (order.OrderId, null);
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra
                return (null, ex.Message);
            }
        }
        public async Task<(OrderDTO order, string error)> GetOrderById(string orderId, string userId)
        {
            try
            {
                var order = await _mobilecontext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId && o.UserId == userId);
                if (order == null)
                {
                    return (null, "Order not found");
                }

                var orderDto = ConvertToDTO(order);
                return (orderDto, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = await _mobilecontext.Orders.ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
               //trả về danh sách rỗng
                return new List<Order>();
            }
        }

        private OrderDTO ConvertToDTO(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            return new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                // Sao chép các thuộc tính khác từ đối tượng Order sang đối tượng OrderDTO
            };
        }

        public async Task<string> DeleteOrderById(string orderId, string userId)
        {
            var order = await _mobilecontext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId && o.UserId == userId);

            if (order != null)
            {
                _mobilecontext.Orders.Remove(order);
                await _mobilecontext.SaveChangesAsync();
                return "Order deleted successfully";
            }
            else
            {
                return "Failed to delete order";
            }
        }
    }  
}
