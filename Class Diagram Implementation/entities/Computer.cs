using BYT_03.entities.Abstract;
using BYT_03.entities.enums;

namespace BYT_03.entities;

[Serializable]
public class Computer : Item, IPoweredByCable
{
    public ComputerType Type { get; set; }

    public string CableType { get; set; }

    public bool Charging { get; set; }


    public Computer()
    {
    }

    public Computer(Computer computer)
    {
        Name = computer.Name;
        Price = computer.Price;
        Brand = computer.Brand;
        Type = computer.Type;
        CableType = computer.CableType;
        Description = computer.Description;
        InStock = computer.InStock;
        Charging = computer.Charging;
    }

    public override string ToString()
    {
        return
            $"Computer: {ItemId}, {Name}, {Brand}, {Description}, {Price}, {Type}, {InStock}, {CableType}, {Charging}";
    }
}