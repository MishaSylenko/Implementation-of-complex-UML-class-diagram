using System.Text.Json.Serialization;

namespace BYT_03.entities;

[Serializable()]
public class InfolineOperator : Worker
{
    public TimeOnly ShiftStart { get; set; }
    public TimeOnly ShiftEnd { get; set; }
    [JsonIgnore] public Worker Worker { get; private set; }

    public InfolineOperator()
    {
    }

    public InfolineOperator(Worker worker, TimeOnly shiftStart, TimeOnly shiftEnd)
    {
        ArgumentNullException.ThrowIfNull(worker, nameof(worker));
        Name = worker.Name;
        Surname = worker.Surname;
        Phone = worker.Phone;
        Email = worker.Email;
        BirthDate = worker.BirthDate;
        HireDate = worker.HireDate;
        Salary = worker.Salary;
        Worker = worker;
        ShiftStart = shiftStart;
        ShiftEnd = shiftEnd;
    }

    public InfolineOperator(InfolineOperator infolineOperator)
    {
        Worker = infolineOperator.Worker;
        ShiftStart = infolineOperator.ShiftStart;
        ShiftEnd = infolineOperator.ShiftEnd;
    }

    public override string ToString()
    {
        return base.ToString() + $", Shift Start: {ShiftStart}, Shift End: {ShiftEnd}";
    }
}