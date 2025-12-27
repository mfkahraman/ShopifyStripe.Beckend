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
            // TO DO
            // Inventory → ReserveStockCommand
            return Task.CompletedTask;
        }
    }
}
