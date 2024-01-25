using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities;

public class OrdemItem : Entity
{
    
    public OrdemItem(Product product, int quantity)
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(product, "Product", "Produto inválido")
                .IsLowerOrEqualsThan(0, quantity, "Quantity", "A quantidade deve ser maior que zero")
            
            );
        
        Product = product;
        Quantity = quantity;
        
        if (product != null)
            Price = product.Price;
        
    }
    
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    
    public decimal Total() => Price * Quantity;
}