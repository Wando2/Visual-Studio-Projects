namespace Store.Domain.Entities;

public class OrdemItem : Entity
{
    
    public OrdemItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = product.Price;
    }
    
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    
    public decimal Total() => Price * Quantity;
}