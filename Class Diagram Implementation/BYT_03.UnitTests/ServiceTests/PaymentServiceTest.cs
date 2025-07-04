using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.enums;
using BYT_03.exceptions;
using BYT_03.exceptions.payment;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class PaymentServiceTests
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
    public void AddOrderTest_ValidOrder()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(Storage.Payments, Has.Count.EqualTo(1));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void AddOrdersTest_ValidOrders()
    {
        var payments = new List<Payment>()
        {
            new Payment()
            {
                Order = _order,
                Date = DateTime.Today,
            },
            new Payment()
            {
                Order = _order,
                Date = DateTime.Today,
            }
        };
        _paymentService.AddPayments(payments);
        Assert.That(Storage.Payments, Has.Count.EqualTo(2));
        _paymentService.RemovePayment(payments[0].PaymentId);
        _paymentService.RemovePayment(payments[1].PaymentId);
    }

    [Test]
    public void GetOrderByIdTest_OrderExists()
    {
        _paymentService.AddPayment(_payment);
        var payment = _paymentService.GetPaymentById(_payment.PaymentId);
        Assert.That(payment.PaymentId, Is.EqualTo(_payment.PaymentId));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void GetOrderByIdTest_OrderDoesNotExist()
    {
        Assert.Throws<PaymentNotFoundException>(() => _paymentService.GetPaymentById(99999));
    }

    [Test]
    public void RemoveOrderTest_OrderExists()
    {
        _paymentService.AddPayment(_payment);
        _paymentService.RemovePayment(_payment.PaymentId);
        Assert.That(Storage.Payments, Has.Count.EqualTo(0));
    }


    [Test]
    public void RemoveOrderTest_OrderDoesNotExist()
    {
        Assert.Throws<PaymentNotFoundException>(() => _paymentService.RemovePayment(99999));
    }

    [Test]
    public void GetOrdersCountTest()
    {
        _paymentService.AddPayment(_payment);
        Assert.That(_paymentService.GetPaymentsCount(), Is.EqualTo(1));
        _paymentService.RemovePayment(_payment.PaymentId);
    }

    [Test]
    public void GetOrdersCountTest_NoOrders()
    {
        Assert.That(_paymentService.GetPaymentsCount(), Is.EqualTo(0));
    }

    [Test]
    public void GetAllOrdersTest()
    {
        _paymentService.AddPayment(_payment);
        var payments = _paymentService.GetAllPayments();
        Assert.That(payments, Has.Count.EqualTo(1));
        _paymentService.RemovePayment(_payment.PaymentId);
    }
}