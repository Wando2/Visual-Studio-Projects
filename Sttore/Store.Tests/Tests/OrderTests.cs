﻿using Store.Domain.Entities;

namespace Store.Tests.Tests;

public class OrderTests
{
    private readonly Customer _customer;
    private readonly Product _product;
    private readonly Discount _discount;
    private readonly Order _order;

    public OrderTests()
    {
        _customer = new Customer("Bruce Wayne", "bubu@gmail.com");
        _product = new Product("Produto1", 10, true);
        _discount = new Discount(10, DateTime.Now.AddDays(5));
        
    }
    
    [Fact]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
    {
      var order = new Order(_customer, 0, null);
      Assert.Equal(8, order.Number.Length);
      
    }
    
    [Fact]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        var order = new Order(_customer, 0, null);
        Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
    }
    
    [Fact]
    public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
    {
        var order = new Order(_customer, 0, null);

        order.AddItem(_product, 1);
        order.Pay(10);
        Assert.Equal(EOrderStatus.WaitingDelivery, order.Status);
    }
    
    [Fact]
    public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        var order = new Order(_customer, 0, null);
        order.Cancel();
        Assert.Equal(EOrderStatus.Canceled, order.Status);
    }
    
    [Fact]
    public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(null, 10);
        Assert.Equal(0, order.Items.Count());
    }
    
}