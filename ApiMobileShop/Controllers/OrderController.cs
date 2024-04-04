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
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateOrder(string userId)
        {
            var (order, error) = await _orderRepository.CreateOrder(userId);
            if (error != null)
            {
                return BadRequest(error);
            }
            return Ok(order);
        }

        [HttpGet("{userId}/{orderId}")]
        public async Task<IActionResult> GetOrderById(string userId, string orderId)
        {
            var (order, error) = await _orderRepository.GetOrderById(orderId, userId);
            if (error != null)
            {
                return NotFound(error);
            }
            return Ok(order);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllOrders(string userId)
        {
            var orders = await _orderRepository.GetAllOrders(userId);
            return Ok(orders);
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
