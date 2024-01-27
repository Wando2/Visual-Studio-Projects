using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;

namespace Store.Domain.Commands;

public class CreateOrderItermCommand : Notifiable<Notification>, ICommandResult
{
    public CreateOrderItermCommand()
    {
        
    }
    
    
    public CreateOrderItermCommand(Guid product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    public Guid Product { get; set; }
    public int Quantity { get; set; }
   
    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(0,Quantity, "Quantity", "A quantidade deve ser maior que zero")
        );
    }
    
}