using MediatR;
using OrderService.Application.Dtos;
using OrderService.Domain.ValueObjects;

namespace OrderService.Application.Commands.CreateOrder
{
    public record CreateOrderCommand(
        string ExternalOrderId,
        Money TotalAmount,
        List<CreateOrderItemDto> Items
    ) : IRequest<int>;
}
