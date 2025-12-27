using OrderService.Domain.Entities;

namespace OrderService.Domain.Events
{
    public record OrderCreatedDomainEvent(Order Order);
}
