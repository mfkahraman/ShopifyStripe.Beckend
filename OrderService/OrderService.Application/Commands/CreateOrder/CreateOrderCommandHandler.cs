using MediatR;
using OrderService.Application.Abstractions;
using OrderService.Domain.Entities;

namespace OrderService.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var items = request.Items
                .Select(i => new OrderItem(
                    i.ProductId,
                    i.Quantity,
                    i.UnitPrice))
                .ToList();

            var order = Domain.Entities.Order.Create(
                request.ExternalOrderId,
                request.TotalAmount,
                items);

            await _orderRepository.AddAsync(order, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
