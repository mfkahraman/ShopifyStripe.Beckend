using OrderService.Application.Dtos;
using OrderService.Domain.Entities;

namespace OrderService.Application.Abstractions
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order, CancellationToken cancellationToken);
        Task<OrderDto?> GetByIdAsync(int orderId, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
