using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.services;

namespace BYT_03.UnitTests.ArgumentsTests;

[TestFixture]
public class ItemArgumentsTests
{
    private readonly ItemService _itemService = new();

    [SetUp]
    public void Setup()
    {
        Storage.LoadData();
    }

    [Test]
    public void ItemIdNotChangesTest()
    {
        Item item = new Computer
        {
            Name = "Name",
            Brand = "Brand",
            Description = "Description",
            Price = 100,
            InStock = 10,
            CableType = "Type",
            Charging = false,
            Type = ComputerType.GAMING
        };
        _itemService.AddItem(item);
        Assert.That(_itemService.GetItemById(item.ItemId).ItemId, Is.EqualTo(item.ItemId));
        _itemService.RemoveItem(item.ItemId);
    }
    
}