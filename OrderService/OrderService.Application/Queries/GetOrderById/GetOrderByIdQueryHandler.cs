using MediatR;
using OrderService.Application.Abstractions;
using OrderService.Application.Dtos;

namespace OrderService.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler
        : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto> Handle(
            GetOrderByIdQuery request,
            CancellationToken ct)
        {
            return await _repository.GetByIdAsync(request.OrderId, ct);
        }
    }
}
