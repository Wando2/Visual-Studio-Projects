using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects;

using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        AddNotifications(new Contract<Document>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Invalid document")
        );
    }
   
    private bool Validate()
    {
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        if (Type == EDocumentType.CPF && Number.Length == 11)
            return true;

        return false;
    }

    public EDocumentType Type { get; private set; }
    public string Number { get; private set; }
}