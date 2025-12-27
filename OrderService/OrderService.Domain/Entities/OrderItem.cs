using OrderService.Domain.Common;
using OrderService.Domain.ValueObjects;

namespace OrderService.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Money UnitPrice { get; private set; }

        private OrderItem() { } // EF Core

        public OrderItem(string productId, int quantity, Money unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
