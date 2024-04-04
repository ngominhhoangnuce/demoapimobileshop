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
        public async Task<(OrderDTO order, string error)> CreateOrder(string userId)//id tạo đơn hàng
        {
            try
            {
                var orderId = Guid.NewGuid().ToString();

                // Tạo đơn hàng mới
                var order = new Order
                {
                    OrderId = orderId,
                    UserId = userId,
                    CreateDay = DateTime.Now
                };

                // Lưu đơn hàng vào cơ sở dữ liệu
                _mobilecontext.Orders.Add(order);
                await _mobilecontext.SaveChangesAsync();

                var orderDto = new OrderDTO
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    Create_Day = order.CreateDay
                };

                return (orderDto, null); // Trả về đơn hàng mới và không có lỗi
            }
            catch (Exception ex)
            {
                return (null, ex.Message); // Trả về null và thông báo lỗi
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

        public async Task<IEnumerable<OrderDTO>> GetAllOrders(string userId)
        {
            try
            {
                var orders = await _mobilecontext.Orders.Where(o => o.UserId == userId).ToListAsync();
                var orderDtos = orders.Select(ConvertToDTO);
                return orderDtos;
            }
            catch (Exception ex)
            {
                // Xử lý exception
                throw; // hoặc thực hiện xử lý khác tùy thuộc vào nhu cầu của bạn
            }
        }

        public async Task<string> DeleteOrderById(string orderId, string userId)
        {
            try
            {
                var order = await _mobilecontext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId && o.UserId == userId);
                if (order == null)
                {
                    return "Order not found";
                }

                _mobilecontext.Orders.Remove(order);
                await _mobilecontext.SaveChangesAsync();
                return null; // Không có lỗi
            }
            catch (Exception ex)
            {
                return ex.Message;
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

    }  
}
