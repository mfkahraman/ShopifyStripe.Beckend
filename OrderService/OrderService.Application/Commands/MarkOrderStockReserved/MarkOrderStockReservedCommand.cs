using MediatR;

namespace OrderService.Application.Commands.MarkOrderStockReserved
{
    public record MarkOrderStockReservedCommand(int OrderId) : IRequest;
}
