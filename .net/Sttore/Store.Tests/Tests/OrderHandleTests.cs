using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repository.Interfaces;
using Store.Tests.Repositories;

namespace Store.Tests.Tests;

public class OrderHandleTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IDeliveryRepository _deliveryFeeRepository;
    private readonly CreateOrderHandler _handler;
    private readonly CreateOrderCommand _command;

    public OrderHandleTests()
    {
        _customerRepository = new FakeCustomerRepo();
        _discountRepository = new FakeDiscountRepo();
        _orderRepository = new FakeOrderRepo();
        _productRepository = new FakeProductRepo();
        _deliveryFeeRepository = new FakeDeliveryRepo();
        _handler = new CreateOrderHandler(_customerRepository, _discountRepository, _orderRepository, _productRepository, _deliveryFeeRepository);
        _command = new CreateOrderCommand();
        _command.Customer = "12345678911";
        _command.ZipCode = "13456789";
        _command.PromoCode = "12345678";
        _command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
        _command.OrderItems.Add(new CreateOrderItermCommand(Guid.NewGuid(), 1));
    }

    [Fact(DisplayName = "Should create order when the command is valid")]
    public void ShouldCreateOrderWhenCommandIsValid()
    {
        var result = (GenericCommandResult)_handler.Handle(_command);
        Assert.True(result.Success);
        
        
    }
}