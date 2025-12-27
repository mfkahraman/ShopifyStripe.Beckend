using OrderService.Domain.Entities;

namespace OrderService.Domain.Events
{
    public record OrderPaidDomainEvent(Order Order);
}
