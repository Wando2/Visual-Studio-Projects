using Store.Domain.Entities;

namespace Store.Domain.Repository.Interfaces;

public interface ICustomerRepository
{
    Customer Get(string document);
}