using BYT_03.entities.Abstract;
using BYT_03.entities.enums;

namespace BYT_03.entities;

[Serializable]
public class Order
{
    private static long _id = 0;
    public long OrderId { get; private set; } = ++_id;

    public User Client { get; private set; }
    private readonly List<ItemQuantity> _itemQuantities = new();
    public IReadOnlyList<ItemQuantity> ItemQuantities => _itemQuantities.AsReadOnly();

    public int Sum => _itemQuantities.Sum(iq => (int)(iq.Item.Price * iq.Quantity));
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Placed;
    public string ShippingAddress { get; set; }
    public OrderShippingType OrderShippingType { get; set; } = OrderShippingType.Courier;
    public Payment Payment { get; set; }

    public static void SetStaticId(long id) => _id = id;

    public Order()
    {
    }

    public Order(Order order)
    {
        OrderId = order.OrderId;
        Client = order.Client;
        _itemQuantities = order._itemQuantities;
        OrderStatus = order.OrderStatus;
        ShippingAddress = order.ShippingAddress;
        OrderShippingType = order.OrderShippingType;
        Payment = order.Payment;
    }


    public void AddItem(Item item, int quantity)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (quantity > item.InStock)
            throw new ArgumentException("Quantity cannot exceed items in stock.");

        var existingItemQuantity = _itemQuantities.FirstOrDefault(iq => iq.Item == item);
        if (existingItemQuantity != null)
        {
            existingItemQuantity.UpdateQuantity(existingItemQuantity.Quantity + quantity);
        }
        else
        {
            var itemQuantity = new ItemQuantity(this, item, quantity);
            _itemQuantities.Add(itemQuantity);
            item.AddOrder(this);
        }
    }

    public void RemoveItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var itemQuantity = _itemQuantities.FirstOrDefault(iq => iq.Item == item);
        if (itemQuantity == null)
        {
            throw new ArgumentException("Item not found in the order.");
        }

        _itemQuantities.Remove(itemQuantity);
        item.RemoveOrder(this);
    }

    public void UpdateItemQuantity(Item item, int quantity)
    {
        ArgumentNullException.ThrowIfNull(item);

        var itemQuantity = _itemQuantities.FirstOrDefault(iq => iq.Item == item);
        if (itemQuantity == null)
        {
            throw new ArgumentException("Item not found in the order.");
        }

        itemQuantity.UpdateQuantity(quantity);
    }

    public void AttachUser(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);
        Client = client;

        if (!client.Orders.ContainsKey(OrderId))
        {
            client.Orders[OrderId] = this;
        }
    }

    public void SetPayment(Payment payment)
    {
        Payment = payment;

        if (payment.Order != this)
        {
            payment.Order = this;
        }
    }
}