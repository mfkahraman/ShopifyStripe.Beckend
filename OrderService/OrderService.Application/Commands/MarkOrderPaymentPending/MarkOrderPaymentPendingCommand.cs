using MediatR;

namespace OrderService.Application.Commands.MarkOrderPaymentPending
{
    public record MarkOrderPaymentPendingCommand(int OrderId) : IRequest;
}
