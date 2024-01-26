using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries;

public class ProductQueriesTests
{
    private readonly List<Product> _products;

    public ProductQueriesTests()
    {
        _products = new List<Product>();
        _products.Add(new Product("Produto 01", 10, true));
        _products.Add(new Product("Produto 02", 10, true));
        _products.Add(new Product("Produto 03", 10, true));
        _products.Add(new Product("Produto 04", 10, false));
        _products.Add(new Product("Produto 05", 10, false));
        
    }
    
    [Fact(DisplayName = "Dado a consulta de produtos ativos, deve retornar 3")]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
        Assert.Equal(3, result.Count());
    }
    
}