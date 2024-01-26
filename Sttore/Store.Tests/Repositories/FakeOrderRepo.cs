using Store.Domain.Entities;
using Store.Domain.Repository.Interfaces;

namespace Store.Tests.Repositories;

public class FakeOrderRepo : IOrderRepository
{
    public void Save(Order order)
    {
        
    }
    
}