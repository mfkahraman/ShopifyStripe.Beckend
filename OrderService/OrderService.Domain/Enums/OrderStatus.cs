namespace OrderService.Domain.Enums
{
    public enum OrderStatus
    {
        Created = 1,
        StockReserved = 2,
        PaymentPending = 3,
        Paid = 4,
        Cancelled = 5,
        Refunded = 6
    }
}
