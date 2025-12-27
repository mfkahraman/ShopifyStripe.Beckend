using OrderService.Domain.Common;

namespace OrderService.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }

        private OrderItem() { }

        public OrderItem(int productId, string productName, int quantity, Money price)
        {
            if (quantity <= 0)
                throw new DomainException("Ürün miktarı sıfırdan büyük olmalıdır.");

            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
