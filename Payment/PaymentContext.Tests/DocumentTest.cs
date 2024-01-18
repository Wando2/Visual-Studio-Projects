namespace PaymentContext.Tests;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

public class DocumentTest
{
    [Fact]

    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.True(doc.Invalid);
    }

}