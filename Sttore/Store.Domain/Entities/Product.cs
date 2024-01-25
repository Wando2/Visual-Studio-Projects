using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public Product(string title, decimal price, bool active)
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Título inválido")
                .IsLowerOrEqualsThan(0, price, "Price", "Preço inválido")
        );
        
        Title = title;
        Price = price;
        Active = active;
    }
    
    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public bool Active { get; private set; }
    
}