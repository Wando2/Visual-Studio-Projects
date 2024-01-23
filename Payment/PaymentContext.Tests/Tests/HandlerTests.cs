using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

public class HandlerTests
{
    public FakeStudentRepo _repository;
    
    public HandlerTests()
        {
            _repository = new FakeStudentRepo();
        }

    [Fact]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new CreateBoletoSubscriptionHandler(_repository);
        var command = new CreateBoletoPaymentCommand();
        command.FirstName = "Vasco";
        command.LastName = "Sousa";
        command.DocumentNumber = "99999999999";
        command.Email = "vasco@gmail.com";
        command.BarCode = "123456789";
        command.BoletoNumber = "123456789";
        command.Number = "123456789";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Vasco Sousa";
        command.PayerDocument = "123456789";
        command.PayerEmail = "vascol@gmail.com";
        command.Street = "Rua 1";
        command.Neighborhood = "Bairro 1";
        command.City = "Cidade 1";
        command.State = "Estado 1";
        command.Country = "País 1";
        command.ZipCode = "123456789";
        command.Type = EDocumentType.CPF;

        handler.Handle(command);
        Assert.False(handler.IsValid);

    }
    
    
    


}