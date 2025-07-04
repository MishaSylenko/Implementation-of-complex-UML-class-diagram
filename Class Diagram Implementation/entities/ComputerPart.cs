using System.Text.Json.Serialization;
using BYT_03.entities.Abstract;

namespace BYT_03.entities;

[Serializable]
public class ComputerPart : Item, INoElectronicPower
{
    public string CompatibleWith { get; set; }

    public ComputerPart()
    {
    }

    public ComputerPart(ComputerPart computerPart)
    {
        Name = computerPart.Name;
        Price = computerPart.Price;
        Brand = computerPart.Brand;
        Description = computerPart.Description;
        InStock = computerPart.InStock;
        CompatibleWith = computerPart.CompatibleWith;
    }

    public override string ToString()
    {
        return $"ComputerPart: {ItemId}, {Name}, {Brand}, {Description}, {Price},{InStock}, {CompatibleWith}";
    }
}