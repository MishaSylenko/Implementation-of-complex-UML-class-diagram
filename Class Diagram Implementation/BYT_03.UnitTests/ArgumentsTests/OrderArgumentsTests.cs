using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.services;

namespace BYT_03.UnitTests.ArgumentsTests;

[TestFixture]
public class OrderArgumentsTests
{
    // OrderService _orderService = new();
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
    //     Date = new DateTime(2022, 1, 1),
    //     PaymentMethod = PaymentMethod.Card
    // };
    //
    // private Item _item = new Computer
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
    // public void OrderIdNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).OrderId, Is.EqualTo(_order.OrderId));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void AttachedUserIdNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).Client.UserId, Is.EqualTo(_order.Client.UserId));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void AttachedItemIdNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).AttachedItems[0].ItemId,
    //         Is.EqualTo(_order.AttachedItems[0].ItemId));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void QuantitiesNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).Quantities, Is.EqualTo(_order.Quantities));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void SumNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).Sum, Is.EqualTo(_order.Sum));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void ShippingAddressNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).ShippingAddress, Is.EqualTo(_order.ShippingAddress));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void OrderStatusNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).OrderStatus, Is.EqualTo(_order.OrderStatus));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void OrderShippingTypeNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).OrderShippingType, Is.EqualTo(_order.OrderShippingType));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
    //
    // [Test]
    // public void PaymentIdNotChangesTest()
    // {
    //     _orderService.AddOrder(_order);
    //     Assert.That(_orderService.GetOrderById(_order.OrderId).Payment.PaymentId, Is.EqualTo(_order.Payment.PaymentId));
    //     _orderService.RemoveOrder(_order.OrderId);
    // }
}