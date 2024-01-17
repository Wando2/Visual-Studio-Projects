using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObjects;

public class Document : ValueObject
{
    public Document(string number)
    {
        Number = number;
        
    }

    public string Number { get; private set; }
}