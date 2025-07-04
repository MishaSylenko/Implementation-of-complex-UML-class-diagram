using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class OrderValidationTests
{
    private readonly OrderService _orderService = new OrderService();

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
    //     Storage.LoadData();
    // }
    //
    // [Test]
    // public void ValidationAttachedUserIdNotPositive()
    // {
    //     const int sum = 500;
    //     const string shippingAddress = "123 Main St";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         Sum = sum,
    //         ShippingAddress = shippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     order.AddItem(_item, 1);
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _orderService.AddOrder(order));
    //     Assert.That(ex.Message, Is.EqualTo("AttachedUserId must be a positive number."));
    // }
    //
    // [Test]
    // public void ValidationAttachedItemIdNull()
    // {
    //     const int sum = 500;
    //     const string shippingAddress = "123 Main St";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         Sum = sum,
    //         ShippingAddress = shippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     order.AttachUser(_client);
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _orderService.AddOrder(order));
    //     Assert.That(ex.Message, Is.EqualTo("AttachedItemId cannot be null or empty."));
    // }

    // [Test]
    // public void ValidationQuantitiesLengthMismatch()
    // {
    //     const long userId = 1;
    //     var attachedItemId = new long[] { 101, 102 };
    //     var invalidQuantities = new int[] { -2 };
    //     const int sum = 500;
    //     const string shippingAddress = "123 Main St";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         AttachedUserId = userId,
    //         AttachedItemId = attachedItemId,
    //         Quantities = invalidQuantities,
    //         Sum = sum,
    //         ShippingAddress = shippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     var ex = Assert.Throws<ArgumentException>(() => _orderService.AddOrder(order));
    //     Assert.That(ex.Message, Is.EqualTo("Quantities must match the length of AttachedItemId and must be positive."));
    // }
    //
    // [Test]
    // public void ValidationSumZero()
    // {
    //     const int invalidSum = 0;
    //     const string shippingAddress = "123 Main St";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         Sum = invalidSum,
    //         ShippingAddress = shippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     order.AttachUser(_client);
    //     order.AddItem(_item, 1);
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _orderService.AddOrder(order));
    //     Assert.That(ex.Message, Is.EqualTo("Sum must be a positive number."));
    // }
    //
    // [Test]
    // public void ValidationShippingAddressEmpty()
    // {
    //     const int sum = 500;
    //     const string invalidShippingAddress = "";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         Sum = sum,
    //         ShippingAddress = invalidShippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     order.AttachUser(_client);
    //     order.AddItem(_item, 1);
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _orderService.AddOrder(order));
    //     Assert.That(ex.Message, Is.EqualTo("ShippingAddress cannot be null or empty."));
    // }
    //
    // [Test]
    // public void AddingItemQuantityGreaterInStock()
    // {
    //     const int sum = 500;
    //     const string invalidShippingAddress = "";
    //     const OrderStatus orderStatus = OrderStatus.Placed;
    //     const OrderShippingType shippingType = OrderShippingType.Courier;
    //
    //     var order = new Order()
    //     {
    //         Sum = sum,
    //         ShippingAddress = invalidShippingAddress,
    //         OrderStatus = orderStatus,
    //         OrderShippingType = shippingType
    //     };
    //     order.AttachUser(_client);
    //
    //     var ex = Assert.Throws<ArgumentException>(() => order.AddItem(_item, 999));
    //     Assert.That(ex.Message, Is.EqualTo("Quantity cannot be greater than items in stock."));
    // }
}