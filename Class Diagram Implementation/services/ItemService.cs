using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions;
using BYT_03.exceptions.item;

namespace BYT_03.services;

public class ItemService
{
    private void AddItemToStorage(Item item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Brand) ||
            string.IsNullOrEmpty(item.Description))
        {
            throw new ItemValidationException("Item is not valid");
        }

        if (item.Price < 0 || item.InStock < 0)
        {
            throw new ItemValidationException("Item price or in stock can't be negative");
        }

        if (!Storage.Items.TryAdd(item.ItemId, item))
        {
            throw new ItemAlreadyExistsException($"Item with id {item.ItemId} already exists");
        }
    }

    public void AddItem(Item item)
    {
        AddItemToStorage(item);
        Storage.SaveChanges();
    }

    public void AddItems(List<Item> items)
    {
        foreach (var item in items)
        {
            AddItemToStorage(item);
        }

        Storage.SaveChanges();
    }

    public Item GetItemById(long id)
    {
        if (Storage.Items.TryGetValue(id, out var value))
        {
            return value;
        }

        throw new ItemNotFoundException($"Item with id {id} not found");
    }

    public int GetItemsCount()
    {
        return Storage.Items.Count;
    }

    public void RemoveItem(long id)
    {
        if (Storage.Items.ContainsKey(id))
        {
            Storage.Items.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new ItemNotFoundException($"Item with id {id} not found");
    }

    public int GetItemStockById(int id)
    {
        return Storage.Items[id].InStock;
    }

    public Dictionary<long, Item> GetAllItems()
    {
        var items = Storage.Items.ToDictionary(item => item.Key, item => item.Value);
        return items;
    }
}