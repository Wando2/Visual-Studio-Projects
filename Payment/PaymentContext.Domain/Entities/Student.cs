using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain;

public class student
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }

    public string Address { get; set; }

    public List<Subscription> Subscriptions { get; set; }

    
}
