using MediatR;
using OrderService.Application.Abstractions;

namespace OrderService.Application.Commands.MarkOrderStockReserved
{
    public class MarkOrderStockReservedCommandHandler
        : IRequestHandler<MarkOrderStockReservedCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public MarkOrderStockReservedCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(
            MarkOrderStockReservedCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(
                request.OrderId,
                cancellationToken);

            if (order is null)
                throw new ApplicationException("Order not found.");

            order.MarkStockReserved();

            await _orderRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
