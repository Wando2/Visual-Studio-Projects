
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public Order(Customer customer, decimal deliveryFee, Discount discount)
    {
        
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(customer, "Customer", "Cliente inválido")
        );
        
        Customer = customer;
        Date = DateTime.Now;
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        _items = new List<OrdemItem>();
        this.deliveryFee = deliveryFee;
        Discount = discount;
        Status = EOrderStatus.WaitingPayment;
    }
    
    
    public Customer Customer { get; private set; }
    public DateTime Date { get; private set; }
    public String Number { get; private set; }
    private IList<OrdemItem> _items { get;  set; }
    public IEnumerable<OrdemItem> Items => _items;
    public decimal deliveryFee { get; private set; }
    public Discount Discount { get; private set; }
    public EOrderStatus Status { get; private set; }

    public decimal Total()
    {
        decimal total = 0;
        
        foreach(var item in Items)
            total += item.Total();
        
        total += deliveryFee;
        total -= Discount != null ? Discount.Value() : 0;

        return total;
    }
    
    public void AddItem(Product product, int quantity)
        {
            
            var item = new OrdemItem(product, quantity);
            if (item.IsValid)
                _items.Add(item);
            
        }
    
    public void Pay(decimal amount)
    {
        if(amount == Total())
            Status = EOrderStatus.WaitingDelivery;
    }
    
    
    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }
    
}