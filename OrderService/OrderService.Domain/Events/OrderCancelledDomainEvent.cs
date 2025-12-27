using OrderService.Domain.Entities;

namespace OrderService.Domain.Events
{
    public record OrderCancelledDomainEvent(Order Order);
}
