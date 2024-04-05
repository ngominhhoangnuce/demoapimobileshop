using ApiMobileShop.Data;

namespace ApiMobileShop.Reponsitories
{
    public interface IOrderDetailRepository
    {
        OrderDetail GetOrderDetailById(int orderId);
        object GetOrderDetailById(string orderId);
    }
}
