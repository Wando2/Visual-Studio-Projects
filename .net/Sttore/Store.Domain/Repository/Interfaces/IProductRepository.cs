using Store.Domain.Entities;

namespace Store.Domain.Repository.Interfaces;

public interface IProductRepository
{
    Product Get(Guid id);
    
    IEnumerable<Product> Get(IEnumerable<Guid> ids);
    
}