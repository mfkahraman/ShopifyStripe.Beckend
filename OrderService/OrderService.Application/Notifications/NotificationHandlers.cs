using MediatR;

namespace OrderService.Application.Notifications
{
    public class OrderCreatedNotificationHandler
        : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(
            OrderCreatedNotification notification,
            CancellationToken cancellationToken)
        {
            // Inventory → ReserveStockCommand
            return Task.CompletedTask;
        }
    }
}
