using NUnit.Framework;
using System;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;

[TestFixture]
public class OrderTests
{
    [Test]
    public void AddNullItem()
    {
        var order = new Order();
        Assert.Throws<ArgumentNullException>(() => order.AddItem(null, 1));
    }

    [Test]
    public void AddValidItem()
    {
        var order = new Order()
        {
            OrderStatus = OrderStatus.Placed,
            ShippingAddress = "123 Main St",
            OrderShippingType = OrderShippingType.Courier
        };
        var item = new Computer()
        {
            Name = "Computer",
            Price = 100,
            InStock = 10
        };
        
        order.AddItem(item, 1);
        
        var itemQuantity = order.ItemQuantities.FirstOrDefault(iq => iq.Item == item);
        Assert.IsNotNull(itemQuantity, "ItemQuantity was not added to the order.");
        Assert.AreEqual(item, itemQuantity.Item, "The added item is incorrect.");
        Assert.AreEqual(1, itemQuantity.Quantity, "The quantity of the added item is incorrect.");
    }


    [Test]
    public void RemoveNullItem()
    {
        var order = new Order();
        Assert.Throws<ArgumentNullException>(() => order.RemoveItem(null));
    }

    [Test]
    public void RemoveItemNotInOrder()
    {
        var order = new Order();
        var item = new TestItem();
        Assert.Throws<ArgumentException>(() => order.RemoveItem(item));
    }

    [Test]
    public void RemoveValidItem()
    {
        var order = new Order()
        {
            OrderStatus = OrderStatus.Placed,
            ShippingAddress = "123 Main St",
            OrderShippingType = OrderShippingType.Courier
        };
        var item = new Computer()
        {
            Name = "Computer",
            Price = 100,
            InStock = 10
        };
        order.AddItem(item, 1);
        
        order.RemoveItem(item);
        
        var itemQuantity = order.ItemQuantities.FirstOrDefault(iq => iq.Item == item);
        Assert.IsNull(itemQuantity, "The item was not removed from the order.");
    }


    [Test]
    public void AttachNullClient()
    {
        var order = new Order();
        Assert.Throws<ArgumentNullException>(() => order.AttachUser(null));
    }

    [Test]
    public void AttachValidClient()
    {
        var order = new Order();
        var client = new Client();
        order.AttachUser(client);
    
        Assert.AreEqual(client, order.Client);
        Assert.Contains(order, client.Orders.Values);
    }

    [Test]
    public void SetValidPayment()
    {
        var order = new Order();
        var payment = new Payment();
        order.SetPayment(payment);

        Assert.AreEqual(payment, order.Payment);
        Assert.AreEqual(order, payment.Order);
    }
    
    [Test]
    public void AddingOrderReverseConnection()
    {
        var order = new Order();
        var client = new Client();
        client.AddOrder(order);
        
        Assert.AreEqual(order.Client, client);
    }

    [Test]
    public void SetPaymentSetsPayment()
    {
        var order = new Order();
        var payment = new Payment();

        order.SetPayment(payment);

        Assert.AreEqual(payment, order.Payment);
        Assert.AreEqual(order, payment.Order);
    }

    [Test]
    public void SetPaymentUpdatesOrder()
    {
        var order1 = new Order();
        var order2 = new Order();
        var payment = new Payment { Order = order1 };

        order2.SetPayment(payment);

        Assert.AreEqual(payment, order2.Payment);
        Assert.AreEqual(order2, payment.Order);
        Assert.IsNull(order1.Payment);
    }

}

public class TestItem : Item
{
}