using ApiMobileShop.Data;

namespace ApiMobileShop.DTO
{
    public class OrderDTO
    {
        public string OrderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal TotalQuantity{ get; set; }
        public DateTime Create_Day { get; set; }
        public IList<OrderDetail> ListOrderDetail { get; set; }
        public OrderDTO ConvertToDTO(Order order)
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
