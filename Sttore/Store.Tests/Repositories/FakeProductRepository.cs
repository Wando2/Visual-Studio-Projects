using Store.Domain.Entities;
using Store.Domain.Repository.Interfaces;

namespace Store.Tests.Repositories;

public class FakeProductRepository : IProductRepository
{
    public Product Get(Guid id)
    {
        return new Product("Produto 01", 10, true);
    }

    public IEnumerable<Product> Get(IEnumerable<Guid> ids)
    {
        var products = new List<Product>();
        products.Add(new Product("Produto 01", 10, true));
        products.Add(new Product("Produto 02", 10, true));
        products.Add(new Product("Produto 03", 10, true));
        products.Add(new Product("Produto 04", 10, false));
        products.Add(new Product("Produto 05", 10, false));
        return products;
    }
}
