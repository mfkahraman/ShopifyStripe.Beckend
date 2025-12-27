using OrderService.Domain.Common;
using OrderService.Domain.Enums;
using OrderService.Domain.Events;
using OrderService.Domain.Exceptions;
using OrderService.Domain.ValueObjects;

namespace OrderService.Domain.Entities
{
    public class Order : AggregateRoot
    {
        public string ExternalOrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money TotalAmount { get; private set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        private Order() { } // EF Core

        public static Order Create(
            string externalOrderId,
            Money totalAmount,
            List<OrderItem> items)
        {
            if (items == null || !items.Any())
                throw new DomainException("Order must have at least one item.");

            var order = new Order
            {
                ExternalOrderId = externalOrderId,
                TotalAmount = totalAmount,
                Status = OrderStatus.Created
            };

            order._items.AddRange(items);
            order.AddDomainEvent(new OrderCreatedDomainEvent(order));

            return order;
        }

        public void MarkStockReserved()
        {
            if (Status != OrderStatus.Created)
                throw new DomainException("Stock can only be reserved for newly created orders.");

            Status = OrderStatus.StockReserved;
            AddDomainEvent(new OrderStockReservedDomainEvent(this));
        }

        public void MarkPaymentPending()
        {
            if (Status != OrderStatus.StockReserved)
                throw new DomainException("Payment can only start after stock reservation.");

            Status = OrderStatus.PaymentPending;
        }

        public void MarkAsPaid()
        {
            if (Status != OrderStatus.PaymentPending)
                throw new DomainException("Order is not ready to be marked as paid.");

            Status = OrderStatus.Paid;
            AddDomainEvent(new OrderPaidDomainEvent(this));
        }

        public void Cancel()
        {
            if (Status != OrderStatus.PaymentPending)
                throw new DomainException("Only pending orders can be cancelled.");

            Status = OrderStatus.Cancelled;
            AddDomainEvent(new OrderCancelledDomainEvent(this));
        }
    }
}
