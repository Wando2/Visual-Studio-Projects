using Store.Domain.Entities;
using Store.Domain.Repository.Interfaces;

namespace Store.Tests.Repositories;

public class FakeCustomerRepository : ICustomerRepository
{
    public Customer Get(string document)
    {
        if (document == "12345678911")
            return new Customer("Bruce Wayne", "vascol@gmail.com");
        return null;
    }




}