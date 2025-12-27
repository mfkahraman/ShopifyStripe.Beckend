using OrderService.Domain.ValueObjects;

namespace OrderService.Application.Dtos
{
    public record CreateOrderItemDto(
        string ProductId,
        int Quantity,
        Money UnitPrice
    );
}
