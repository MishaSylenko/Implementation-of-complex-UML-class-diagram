using BYT_03.entities.enums;
using Newtonsoft.Json;

namespace BYT_03.entities;

[Serializable()]
public class ServiceMan : Worker
{
    public JobType Type { get; set; }
    private readonly List<WorkerTask> _tasks = new();
    public IReadOnlyList<WorkerTask> Tasks => _tasks.AsReadOnly();
    [JsonIgnore] public Worker Worker { get; private set; }

    public ServiceMan()
    {
    }

    public ServiceMan(Worker worker, JobType type)
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
        Type = type;
        _tasks = [];
    }

    public ServiceMan(ServiceMan serviceMan)
    {
        ArgumentNullException.ThrowIfNull(serviceMan);
        Worker = serviceMan.Worker;
        Type = serviceMan.Type;
        _tasks.AddRange(serviceMan._tasks);
    }

    public void AddTask(WorkerTask task)
    {
        ArgumentNullException.ThrowIfNull(task);
        if (!_tasks.Contains(task))
        {
            _tasks.Add(task);
            if (!task.AttachedServiceMen.Contains(this))
            {
                task.AttachWorker(this);
            }
        }
    }

    public void RemoveTask(WorkerTask task)
    {
        ArgumentNullException.ThrowIfNull(task);
        if (_tasks.Remove(task))
        {
            task.DetachWorker(this);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Job Type: {Type}";
    }
}