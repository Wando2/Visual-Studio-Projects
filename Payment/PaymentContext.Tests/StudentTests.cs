using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
namespace PaymentContext.Tests;

public class StudentTests
{
        private readonly Student _student;
        private readonly PayPalPayment _payment;

        private readonly BoletoPayment _payment2;

        private readonly Subscription _subscription;

        private readonly Subscription _subscription2;

        public StudentTests()
        {
                _student = new Student(
                        new Name("Bruce", "Wayne"),
                        new Document("35111507799", EDocumentType.CPF),
                        new Email("vasco@gmail.com")
                );

                _payment = new PayPalPayment(
                        DateTime.Now,
                        DateTime.Now.AddDays(5),
                        10,
                        10,
                        "Wayne Corp",
                        new Document("35111507799", EDocumentType.CPF),
                        new Email("vasco@gmail.com"),
                        new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000"),
                        "12345678");

                _payment2 = new BoletoPayment(
                        DateTime.Now,
                        DateTime.Now.AddDays(5),
                        10,
                        10,
                        "Wayne Corp",
                        new Document("35111507799", EDocumentType.CPF),
                        new Email("vascol@gmail.com"),
                        new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000"),
                        "12345678",
                        "12345678");


                _subscription = new Subscription(null);

                _subscription2 = new Subscription(null);




        }

        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
                _subscription.AddPayment(_payment);
                _subscription2.AddPayment(_payment2);

                _student.AddSubscription(_subscription);
                _student.AddSubscription(_subscription2);

                Assert.False(_student.IsValid);
               
        }
        
        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
                _student.AddSubscription(_subscription);
                Assert.False(_student.IsValid);
        }
        
        [Fact]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
                _subscription.AddPayment(_payment);
                _student.AddSubscription(_subscription);
                Assert.True(_student.IsValid);
        }
        
      
        
}