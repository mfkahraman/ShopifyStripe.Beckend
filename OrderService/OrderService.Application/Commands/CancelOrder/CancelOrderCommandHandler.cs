using MediatR;
using OrderService.Application.Abstractions;

namespace OrderService.Application.Commands.CancelOrder
{
    public class CancelOrderCommandHandler
        : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public async Task Handle(
            CancelOrderCommand request,
            CancellationToken ct)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId, ct)
                         ?? throw new ApplicationException("Order not found.");

            order.Cancel();

            await _orderRepository.SaveChangesAsync(ct);
        }
    }
}
