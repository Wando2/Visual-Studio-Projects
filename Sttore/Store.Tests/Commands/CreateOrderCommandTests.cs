using Store.Domain.Commands;

namespace Store.Tests.Commands;

public class CreateOrderCommandTests
{
    
        private CreateOrderCommand _command;

      
    
    
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
    
    [Fact]
    public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "Lil'gabi";
        command.ZipCode = "13456789";
        command.PromoCode = "123456789";
        command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        command.Validate();
        Assert.True(command.IsValid);
    }
    
    [Fact]
    public void Given_Empty_ZipCode_Order_Should_Not_Be_Created()
    {
        var command = new CreateOrderCommand();
        command.Customer = "John Doe";
        command.ZipCode = "";
        command.PromoCode = "PROMO123";
        command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        command.Validate();
        Assert.False(command.IsValid);
    }
    
    
}