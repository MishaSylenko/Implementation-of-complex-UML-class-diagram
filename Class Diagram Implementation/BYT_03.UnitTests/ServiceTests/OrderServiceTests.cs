using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.exceptions;
using BYT_03.exceptions.order;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class OrderServiceTests
{
    // OrderService _orderService = new OrderService();
    //
    // Client _client = new()
    // {
    //     Name = "Name",
    //     Surname = "Surname",
    //     Email = "Email",
    //     Phone = "Phone",
    //     Address = "Address",
    //     ShippingAddress = "ShippingAddress",
    //     Cards = ["Card1", "Card2"],
    //     FavoriteItems = [101, 102],
    //     BirthDate = new DateOnly(1990, 1, 1)
    // };
    //
    // Order _order = new()
    // {
    //     Sum = 500,
    //     ShippingAddress = "123 Main St",
    //     OrderStatus = OrderStatus.Placed,
    //     OrderShippingType = OrderShippingType.Courier,
    // };
    //
    // Payment _payment = new()
    // {
    //     Date = DateTime.Today,
    //     PaymentMethod = PaymentMethod.Card
    // };
    //
    // Item _item = new Computer
    // {
    //     Name = "Gaming PC",
    //     Price = 1500,
    //     Brand = "BrandA",
    //     Type = ComputerType.GAMING,
    //     CableType = "TypeC",
    //     Description = "Gaming PC",
    //     Charging = true,
    //     InStock = 10
    // };
    //
    // [SetUp]
    // public void Setup()
    // {
    //     _order.SetPayment(_payment);
    //     _order.AttachUser(_client);
    //     _order.AddItem(_item, 1);
    //
    //     Storage.LoadData();
    // }
    //
    // [Test]
    // public void AddOrderTest_ValidOrder()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(Storage.Orders, Has.Count.EqualTo(1));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void AddOrdersTest_ValidOrders()
    // {
    //     _orderService.AddOrders(new List<Order>() { _order });
    //     Assert.That(Storage.Orders, Has.Count.EqualTo(1));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void GetOrderByIdTest_OrderExists()
    // {
    //     _orderService.AddOrder(_order);
    //     var order = _orderService.GetOrderById(_order.OrderId);
    //     Assert.That(order, Is.Not.Null);
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void GetOrderByIdTest_OrderDoesNotExist()
    // {
    //     Assert.Throws<OrderNotFoundException>(() => _orderService.GetOrderById(99999));
    // }
    //
    // [Test]
    // public void RemoveOrderTest_OrderExists()
    // {
    //     _orderService.AddOrder(_order);
    //     _orderService.RemoveOrder(_order.OrderId);
    //     Assert.That(Storage.Orders, Has.Count.EqualTo(0));
    // }
    //
    //
    // [Test]
    // public void RemoveOrderTest_OrderDoesNotExist()
    // {
    //     Assert.Throws<OrderNotFoundException>(() => _orderService.RemoveOrder(99999));
    // }
    //
    // [Test]
    // public void GetOrdersCountTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrdersCount(), Is.EqualTo(1));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void GetOrdersCountTest_NoOrders()
    // {
    //     Assert.That(_orderService.GetOrdersCount(), Is.EqualTo(0));
    // }
    //
    // [Test]
    // public void GetAllOrdersTest()
    // {
    //     _orderService.AddOrder(_order);
    //     var orders = _orderService.GetAllOrders();
    //     Assert.That(orders, Has.Count.EqualTo(1));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
}