using ApiMobileShop.Data;
using ApiMobileShop.DTO;

namespace ApiMobileShop.Reponsitories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MobileContext _mydbcontext; // Thay YourDatabaseContext bằng context của bạn

        public OrderDetailRepository(MobileContext context)
        {
            _mydbcontext = context;
        }

        public OrderDetailDTO GetOrderDetailById(string orderId);

    }
}
