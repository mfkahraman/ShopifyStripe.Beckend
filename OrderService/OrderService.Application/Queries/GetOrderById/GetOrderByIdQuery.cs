using MediatR;
using OrderService.Application.Dtos;

namespace OrderService.Application.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
}
