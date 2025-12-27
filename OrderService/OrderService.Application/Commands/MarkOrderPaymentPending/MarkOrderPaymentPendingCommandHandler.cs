using MediatR;
using OrderService.Application.Abstractions;

namespace OrderService.Application.Commands.MarkOrderPaymentPending
{
    public class MarkOrderPaymentPendingCommandHandler
        : IRequestHandler<MarkOrderPaymentPendingCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public async Task Handle(
            MarkOrderPaymentPendingCommand request,
            CancellationToken ct)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId, ct)
                         ?? throw new ApplicationException("Order not found.");

            order.MarkPaymentPending();

            await _orderRepository.SaveChangesAsync(ct);
        }
    }
}