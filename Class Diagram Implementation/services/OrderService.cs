using System.Runtime.CompilerServices;
using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions;
using BYT_03.exceptions.order;

namespace BYT_03.services;

public class OrderService
{
    public void AddOrder(Order order)
    {
        if (order.Client == null)
        {
            throw new ArgumentException("AttachedUserId must be a positive number.");
        }

        if (order.ItemQuantities.Count == 0)
        {
            throw new ArgumentException("AttachedItemId cannot be null or empty.");
        }

        if (order.ItemQuantities.Any(item => item.Item.ItemId <= 0))
        {
            throw new ArgumentException("Each item in AttachedItemId must be a positive number.");
        }

        var totalItems = order.ItemQuantities.Sum(itemQuantity => itemQuantity.Quantity);

        if (order.ItemQuantities == null || order.ItemQuantities.Count != totalItems)
        {
            throw new ArgumentException("Quantities must match the length of AttachedItemId and must be positive.");
        }

        if (order.Sum <= 0)
        {
            throw new ArgumentException("Sum must be a positive number.");
        }

        if (string.IsNullOrWhiteSpace(order.ShippingAddress))
        {
            throw new ArgumentException("ShippingAddress cannot be null or empty.");
        }

        Storage.Orders.Remove(order.OrderId);
        Storage.Orders.Add(order.OrderId, order);
        Storage.SaveChanges();
    }

    public void AddOrders(List<Order> orders)
    {
        foreach (var order in orders)
        {
            Storage.Orders.Add(order.OrderId, order);
        }

        Storage.SaveChanges();
    }

    public Order GetOrderById(long id)
    {
        if (Storage.Orders.ContainsKey(id))
        {
            return new Order(Storage.Orders[id]);
        }

        throw new OrderNotFoundException($"Order with id {id} not found");
    }

    public int GetOrdersCount()
    {
        return Storage.Orders.Count;
    }

    public void RemoveOrder(long id)
    {
        if (Storage.Orders.ContainsKey(id))
        {
            Storage.Orders.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new OrderNotFoundException($"Order with id {id} not found");
    }


    public Dictionary<long, Order> GetAllOrders()
    {
        return Storage.Orders.ToDictionary(idOrder => idOrder.Key, idOrder => new Order(idOrder.Value));
    }
}