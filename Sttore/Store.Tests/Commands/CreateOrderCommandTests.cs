using Store.Domain.Commands;

namespace Store.Tests.Commands;

public class CreateOrderCommandTests
{
    
        private CreateOrderCommand _command;

        public CreateOrderCommandTests()
        {
            _command = new CreateOrderCommand();
            _command.Customer = "John Doe";
            _command.ZipCode = "123456";
            _command.PromoCode = "PROMO123";
            _command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        }
    
    
    [Fact]
    public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "13456789";
        command.PromoCode = "123456789";
        command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        command.Validate();
        Assert.False(command.IsValid);
    }
}