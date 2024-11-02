using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class CreateBoletoSubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoPaymentCommand>
{
    public readonly IStudentRepository _repository;
    
    public CreateBoletoSubscriptionHandler(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    public ICommandResult Handle(CreateBoletoPaymentCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }
        
        if (_repository.DocumentExists(command.DocumentNumber))
        {
            AddNotification("Document", "Este CPF já está em uso");
        }
        
        if (_repository.EmailExists(command.Email))
        {
            AddNotification("Email", "Este email já está em uso");
        }
        
        // Gerar os VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.DocumentNumber, command.Type);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
        
        var _student = new Student(name, document, email);
        var _subscription = new Subscription(DateTime.Now.AddMonths(1));
        
        var _payment = new BoletoPayment(command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.Type), email,address, command.BarCode, command.BoletoNumber);
        
        _subscription.AddPayment(_payment);
        _student.AddSubscription(_subscription);
        
        AddNotifications(name, document, email, address, _student, _subscription, _payment);

        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        
        _repository.CreateSubscription(_student);
    
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}