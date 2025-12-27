using MediatR;

namespace OrderService.Application.Commands.CancelOrder
{
    public record CancelOrderCommand(int OrderId) : IRequest;
}
