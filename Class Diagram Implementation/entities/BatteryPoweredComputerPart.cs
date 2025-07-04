namespace BYT_03.entities;

[Serializable()]
public class BatteryPoweredComputerPart : ComputerPart, IPoweredByBatteries
{
    public int BatteriesQuantity { get; set; }
    public string BatteryType { get; set; }
}