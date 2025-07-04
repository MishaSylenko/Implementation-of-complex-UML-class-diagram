namespace BYT_03.entities;

public interface IPoweredByCable
{
    public string CableType { get; set; }
    public bool Charging { get; set; }
}