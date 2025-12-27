using MediatR;
using OrderService.Application.Abstractions;

namespace OrderService.Application.Commands.MarkOrderPaid
{
    public class MarkOrderPaidCommandHandler
        : IRequestHandler<MarkOrderPaidCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public async Task Handle(
            MarkOrderPaidCommand request,
            CancellationToken ct)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId, ct)
                         ?? throw new ApplicationException("Order not found.");

            order.MarkAsPaid();

            await _orderRepository.SaveChangesAsync(ct);
        }
    }
}
