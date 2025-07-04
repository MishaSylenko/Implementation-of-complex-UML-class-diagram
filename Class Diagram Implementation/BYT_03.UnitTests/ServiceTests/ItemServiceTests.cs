using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.entities.enums;
using BYT_03.exceptions.item;
using BYT_03.services;

namespace BYT_03.UnitTests
{
    [TestFixture]
    public class ItemServiceTests
    {
        // private readonly ItemService _itemService = new();
        //
        // [SetUp]
        // public void Setup()
        // {
        //     Storage.LoadData();
        // }
        //
        // [Test]
        // public void AddItemTest_ValidItem()
        // {
        //     var item = new Computer
        //     {
        //         Name = "Name",
        //         Brand = "Brand",
        //         Description = "Description",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     _itemService.AddItem(item);
        //     Assert.That(Storage.Items, Has.Count.EqualTo(1));
        //     _itemService.RemoveItem(item.ItemId);
        // }
        //
        // [Test]
        // public void AddItemsTest_ValidItems()
        // {
        //     var items = new List<Item>
        //     {
        //         new Computer
        //         {
        //             Name = "Name1",
        //             Brand = "Brand1",
        //             Description = "Description1",
        //             Price = 100,
        //             InStock = 10,
        //             CableType = "Type1",
        //             Charging = false,
        //             Type = ComputerType.GAMING
        //         },
        //         new Computer
        //         {
        //             Name = "Name2",
        //             Brand = "Brand2",
        //             Description = "Description2",
        //             Price = 150,
        //             InStock = 5,
        //             CableType = "Type2",
        //             Charging = true,
        //             Type = ComputerType.WORK
        //         }
        //     };
        //     _itemService.AddItems(items);
        //     Assert.That(Storage.Items, Has.Count.EqualTo(2));
        //     _itemService.RemoveItem(items[0].ItemId);
        //     _itemService.RemoveItem(items[1].ItemId);
        // }
        //
        // [Test]
        // public void TryAddInvalidItemTest_NegativePrice()
        // {
        //     var item = new Computer
        //     {
        //         Name = "Name",
        //         Brand = "Brand",
        //         Description = "Description",
        //         Price = -2,
        //         InStock = 10,
        //         CableType = "Type",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     Assert.Throws<ItemValidationException>(() => _itemService.AddItem(item));
        // }
        //
        // [Test]
        // public void TryAddInvalidItemTest_NullProperties()
        // {
        //     var item = new Computer
        //     {
        //         Name = null,
        //         Brand = null,
        //         Description = "Description",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     Assert.Throws<ItemValidationException>(() => _itemService.AddItem(item));
        // }
        //
        // [Test]
        // public void GetItemById_ValidId_ReturnsItem()
        // {
        //     var item = new Computer
        //     {
        //         Name = "ValidName",
        //         Brand = "Brand",
        //         Description = "Description",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     _itemService.AddItem(item);
        //     var retrievedItem = _itemService.GetItemById(item.ItemId);
        //     Assert.That(retrievedItem, Is.EqualTo(item));
        //     _itemService.RemoveItem(item.ItemId);
        // }
        //
        // [Test]
        // public void GetItemById_InvalidId_ThrowsException()
        // {
        //     Assert.Throws<ItemNotFoundException>(() => _itemService.GetItemById(9999));
        // }
        //
        // [Test]
        // public void RemoveItem_ValidId_RemovesItem()
        // {
        //     var item = new Computer
        //     {
        //         Name = "RemovableName",
        //         Brand = "Brand",
        //         Description = "Description",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     _itemService.AddItem(item);
        //     _itemService.RemoveItem(item.ItemId);
        //     Assert.Throws<ItemNotFoundException>(() => _itemService.GetItemById(item.ItemId));
        // }
        //
        // [Test]
        // public void RemoveItem_InvalidId_ThrowsException()
        // {
        //     Assert.Throws<ItemNotFoundException>(() => _itemService.RemoveItem(9999));
        // }
        //
        // [Test]
        // public void GetItemsCount_ReturnsCorrectCount()
        // {
        //     var item1 = new Computer
        //     {
        //         Name = "Name1",
        //         Brand = "Brand1",
        //         Description = "Description1",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type1",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     var item2 = new Computer
        //     {
        //         Name = "Name2",
        //         Brand = "Brand2",
        //         Description = "Description2",
        //         Price = 200,
        //         InStock = 20,
        //         CableType = "Type2",
        //         Charging = true,
        //         Type = ComputerType.WORK
        //     };
        //     _itemService.AddItem(item1);
        //     _itemService.AddItem(item2);
        //     Assert.That(_itemService.GetItemsCount(), Is.EqualTo(2));
        //     _itemService.RemoveItem(item1.ItemId);
        //     _itemService.RemoveItem(item2.ItemId);
        // }
        //
        // [Test]
        // public void GetAllItems_ReturnsAllItems()
        // {
        //     var item1 = new Computer
        //     {
        //         Name = "Name1",
        //         Brand = "Brand1",
        //         Description = "Description1",
        //         Price = 100,
        //         InStock = 10,
        //         CableType = "Type1",
        //         Charging = false,
        //         Type = ComputerType.GAMING
        //     };
        //     var item2 = new Computer
        //     {
        //         Name = "Name2",
        //         Brand = "Brand2",
        //         Description = "Description2",
        //         Price = 200,
        //         InStock = 20,
        //         CableType = "Type2",
        //         Charging = true,
        //         Type = ComputerType.GAMING
        //     };
        //     _itemService.AddItem(item1);
        //     _itemService.AddItem(item2);
        //     var allItems = _itemService.GetAllItems();
        //     Assert.That(allItems, Has.Count.EqualTo(2));
        //     _itemService.RemoveItem(item1.ItemId);
        //     _itemService.RemoveItem(item2.ItemId);
        // }
    }
}