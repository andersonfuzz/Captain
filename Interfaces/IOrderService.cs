using Captain.Dtos;

namespace Captain.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetAllAsync();
    Task<OrderResponse?> GetByIdAsync(Guid id);
    Task<OrderResponse> CreateAsync(CreateOrderRequest request);
    Task<OrderResponse?> UpdateAsync(Guid id, UpdateOrderRequest request);
    Task<bool> DeleteAsync(Guid id);
}