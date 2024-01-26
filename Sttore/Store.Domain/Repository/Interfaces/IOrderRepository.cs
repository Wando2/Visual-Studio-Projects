using Store.Domain.Entities;

namespace Store.Domain.Repository.Interfaces;

public interface IOrderRepository
{
    void Save(Order order);
}