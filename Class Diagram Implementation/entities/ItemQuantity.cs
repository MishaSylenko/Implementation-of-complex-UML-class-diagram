using BYT_03.entities.Abstract;

namespace BYT_03.entities;

public class ItemQuantity
{
    public Order Order { get; private set; }
    public Item Item { get; private set; }
    public int Quantity { get; private set; }

    public ItemQuantity(Order order, Item item, int quantity)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be a positive number.", nameof(quantity));

        if (quantity > item.InStock)
            throw new ArgumentException("Quantity cannot exceed items in stock.", nameof(quantity));

        Order = order;
        Item = item;
        Quantity = quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be a positive number.", nameof(quantity));

        if (quantity > Item.InStock)
            throw new ArgumentException("Quantity cannot exceed items in stock.", nameof(quantity));

        Quantity = quantity;
    }
}