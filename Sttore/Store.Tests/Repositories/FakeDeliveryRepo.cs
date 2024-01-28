using Store.Domain.Repository.Interfaces;

namespace Store.Tests.Repositories;

public class FakeDeliveryRepo : IDeliveryRepository
{
    public decimal Get(string zipCode)
    {
        return 10;
    }
}