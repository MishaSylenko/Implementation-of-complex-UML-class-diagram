namespace BYT_03.entities;

[Serializable]
public class PoweredComputerPart : ComputerPart, IPoweredByCable
{
    public string CableType { get; set; }
    public bool Charging { get; set; }

    public PoweredComputerPart()
    {
    }

    public PoweredComputerPart(PoweredComputerPart poweredComputerPart)
    {
        Name = poweredComputerPart.Name;
        Price = poweredComputerPart.Price;
        Brand = poweredComputerPart.Brand;
        Description = poweredComputerPart.Description;
        InStock = poweredComputerPart.InStock;
        CompatibleWith = poweredComputerPart.CompatibleWith;
        CableType = poweredComputerPart.CableType;
        Charging = poweredComputerPart.Charging;
    }
    
    public override string ToString()
    {
        return $"PoweredComputerPart: {ItemId}, {Name}, {Brand}, {Description}, {Price},{InStock}, {CompatibleWith}, {CableType}, {Charging}";
    }
}