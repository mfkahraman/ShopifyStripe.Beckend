namespace OrderService.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ExternalOrderId { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
    }
}
