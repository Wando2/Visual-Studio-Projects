using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repository.Interfaces;
using Store.Domain.Utils;

namespace Store.Domain.Handlers;

public class CreateOrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IDeliveryRepository _deliveryFeeRepository;
    
    
    public CreateOrderHandler(ICustomerRepository customerRepository, IDiscountRepository discountRepository, IOrderRepository orderRepository, IProductRepository productRepository, IDeliveryRepository deliveryFeeRepository)
    {
        _customerRepository = customerRepository;
        _discountRepository = discountRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _deliveryFeeRepository = deliveryFeeRepository;
    }
    
    public ICommandResult Handle(CreateOrderCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
        
        // Gerar o pedido
        var customer = _customerRepository.Get(command.Customer);
        var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);
        var discount = _discountRepository.Get(command.PromoCode);
        
        var products = _productRepository.Get(ExtractGuids.Extract(command.OrderItems)).ToList();
        var order = new Order(customer, deliveryFee, discount);
        foreach (var item in command.OrderItems)
        {
            var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
            order.AddItem(product, item.Quantity);
        }

        // 5. Agrupa as notificações
        AddNotifications(order.Notifications);

        // 6. Verifica se deu tudo certo
        if (!IsValid)
            return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);
        
        // 7. Retorna o resultado
        _orderRepository.Save(order);
        return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        
        
    }
}