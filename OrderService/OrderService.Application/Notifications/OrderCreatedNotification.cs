using MediatR;
using OrderService.Domain.Events;

namespace OrderService.Application.Notifications
{
    public record OrderCreatedNotification(
        OrderCreatedDomainEvent DomainEvent
    ) : INotification;
}
