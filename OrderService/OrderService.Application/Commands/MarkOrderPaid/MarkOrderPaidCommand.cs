using MediatR;

namespace OrderService.Application.Commands.MarkOrderPaid
{
    public record MarkOrderPaidCommand(int OrderId) : IRequest;
}
