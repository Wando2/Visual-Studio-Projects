namespace Store.Domain.Entities;

public class Discount : Entity 
{
    public Discount(decimal amount, DateTime expireDate)
    {
        Amount = amount;
        ExpireDate = expireDate;
        Active = true;
    }

    public decimal Amount { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public bool Active { get; private set; }

    public void Activate() => Active = true;
    public void Deactivate() => Active = false;

    public bool IsValid() => DateTime.Now <= ExpireDate && Active;
    
    public decimal Value() => IsValid() ? Amount : 0;
}