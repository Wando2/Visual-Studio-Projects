using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities;

public class OrdemItem : Entity
{
    
    public OrdemItem(Product product, int quantity)
    {
      
        if (product == null)
        {
            AddNotification("Product", "Produto inválido");
            return;
        }

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(quantity, 0, "Quantity", "A quantidade deve ser maior que zero")
        );
        
        Product = product;
        Quantity = quantity;
        
      
        
    }
    
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    
    public decimal Total() => Price * Quantity;
}