using ApiMobileShop.Data;
using ApiMobileShop.DTO;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateOrder(string userId, [FromBody] Order order)
        {
            var (orderId, error) = await _orderRepository.CreateOrder(userId, order);

            if (error != null)
            {
                return BadRequest(error);
            }

            return Ok(new { orderId });
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(string orderId)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailById(orderId);

            if (orderDetail == null)
            {
                return NotFound(); // Trả về mã lỗi 404 Not Found nếu không tìm thấy đơn hàng
            }

            return Ok(orderDetail); // Trả về mã lỗi 200 OK cùng với dữ liệu đơn hàng nếu tìm thấy thành công
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderRepository.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về mã lỗi HTTP 400 (Bad Request)
                return BadRequest("Bad Request: " + ex.Message);
            }
        }

        [HttpDelete("{userId}/{orderId}")]
        public async Task<IActionResult> DeleteOrderById(string userId, string orderId)
        {
            var error = await _orderRepository.DeleteOrderById(orderId, userId);
            if (error != null)
            {
                return BadRequest(error);
            }
            return Ok("Order deleted successfully");
        }
    }
}
