namespace Store.Domain.Entities;

public class Order
{
    public Order(Customer customer, decimal deliveryFee, Discount discount)
    {
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
    
}