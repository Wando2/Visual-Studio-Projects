using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;


namespace PaymentContext.Domain.Commands;

public class CreatePaypalPaymentCommand : Notifiable<Notification>, ICommand
{
    public string TransactionCode { get; set; }
    public string Payer { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string PayerDocument { get; set; }
    public string PayerEmail { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public EDocumentType Type { get; private set; }
    public string DocumentNumber { get; private set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<CreatePaypalPaymentCommand>()
            .Requires()
            .IsLowerOrEqualsThan(PaidDate, DateTime.Now, "PaidDate", "PaidDate should not be in the future")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Total", "Total should not be less than TotalPaid")
            .IsNotNullOrEmpty(Payer, "Payer", "Payer should not be null or empty")
            .IsEmail(PayerEmail, "PayerEmail", "PayerEmail should be a valid email")
            .IsNotNullOrEmpty(FirstName, "FirstName", "FirstName should not be null or empty")
            .IsNotNullOrEmpty(LastName, "LastName", "LastName should not be null or empty")
            .IsEmail(Email, "Email", "Email should be a valid email")
            .IsNotNullOrEmpty(Street, "Street", "Street should not be null or empty")
            .IsNotNullOrEmpty(Number, "Number", "Number should not be null or empty")
            .IsNotNullOrEmpty(Neighborhood, "Neighborhood", "Neighborhood should not be null or empty")
            .IsNotNullOrEmpty(City, "City", "City should not be null or empty")
            .IsNotNullOrEmpty(State, "State", "State should not be null or empty")
            .IsNotNullOrEmpty(Country, "Country", "Country should not be null or empty")
            .IsNotNullOrEmpty(ZipCode, "ZipCode", "ZipCode should not be null or empty")
        );
    }
   
}