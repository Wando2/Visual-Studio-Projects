using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands;

public class CreateOrderCommand : Notifiable<Notification>, ICommandResult
{
    public CreateOrderCommand()
    {
        OrderItems = new List<CreateOrderItermCommand>();
    }
    
    public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItermCommand> orderItems)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        OrderItems = orderItems;
    }
    
    public string Customer { get; set; }
    public IList<CreateOrderItermCommand> OrderItems { get; set; }
    public string ZipCode { get; set; }
    public string PromoCode { get; set; }
    
    public void Validate()
    {
      AddNotifications(
          new Contract<Notification>()
              .Requires()
              .IsGreaterThan(0,OrderItems.Count, "OrderItems", "Nenhum item do pedido foi encontrado")
              .IsNotNullOrEmpty(Customer, "Customer", "Customer is required")
              .IsNotNullOrEmpty(ZipCode, "ZipCode", "ZipCode is required")
              .IsNotNullOrEmpty(PromoCode, "PromoCode", "PromoCode is required") 
      );
    }
}