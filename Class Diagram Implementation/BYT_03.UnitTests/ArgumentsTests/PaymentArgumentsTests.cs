using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.services;

namespace BYT_03.UnitTests.ArgumentsTests;

[TestFixture]
public class PaymentArgumentsTests
{
    PaymentService _paymentService = new PaymentService();

    Order _order = new()
    {
        ShippingAddress = "123 Main St",
        OrderStatus = OrderStatus.Placed,
        OrderShippingType = OrderShippingType.Courier,
    };

    Payment _payment = new()
    {
        Date = DateTime.Today,
        PaymentMethod = PaymentMethod.Card
    };

    [SetUp]
    public void Setup()
    {
        _order.SetPayment(_payment);
        Storage.LoadData();
    }

    [Test]
    public void PaymentIdNotChangesTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentById(_payment.PaymentId).PaymentId, Is.EqualTo(_payment.PaymentId));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void DateNotChangesTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentById(_payment.PaymentId).Date, Is.EqualTo(_payment.Date));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void OrderIdNotChangesTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentById(_payment.PaymentId).Order.OrderId,
            Is.EqualTo(_payment.Order.OrderId));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void PaymentMethodNotChangesTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentById(_payment.PaymentId).PaymentMethod,
            Is.EqualTo(_payment.PaymentMethod));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void PaymentStatusNotChangesTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentById(_payment.PaymentId).PaymentStatus,
            Is.EqualTo(_payment.PaymentStatus));
        _paymentService.RemovePayment(_payment.PaymentId);
    }
}