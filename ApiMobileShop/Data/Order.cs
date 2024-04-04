namespace ApiMobileShop.Data
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }  
        public DateTime CreateDay { get; set; }
        public DateTime? FinishDay { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string HomeAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public virtual IList<OrderDetail> ListOrderDetail { get; set; }     
    }
}
