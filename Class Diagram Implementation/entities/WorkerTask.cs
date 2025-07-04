using BYT_03.entities.Abstract;

namespace BYT_03.entities;

public class WorkerTask
{
    private static long _id = 0;

    private readonly List<ServiceMan> _attachedServiceMen = new();
    private readonly List<Item> _itemsToRepair = new();

    public long WorkerTaskId { get; private set; } = ++_id;
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Priority { get; private set; }
    public DateTime Deadline { get; private set; }
    public bool Done { get; private set; }

    public IReadOnlyList<ServiceMan> AttachedServiceMen => _attachedServiceMen.AsReadOnly();
    public IReadOnlyList<Item> ItemsToRepair => _itemsToRepair.AsReadOnly();

    public WorkerTask()
    {
    }

    public WorkerTask(string name, string description, int priority, DateTime deadline)
    {
        Name = name;
        Description = description;
        Priority = priority;
        Deadline = deadline;
        Done = false;
    }

    public WorkerTask(WorkerTask workerTask)
    {
        WorkerTaskId = workerTask.WorkerTaskId;
        Name = workerTask.Name;
        Description = workerTask.Description;
        Priority = workerTask.Priority;
        Deadline = workerTask.Deadline;
        Done = workerTask.Done;
        _attachedServiceMen.AddRange(workerTask._attachedServiceMen);
        _itemsToRepair.AddRange(workerTask._itemsToRepair);
    }

    public void AttachWorker(ServiceMan worker)
    {
        ArgumentNullException.ThrowIfNull(worker);
        if (!_attachedServiceMen.Contains(worker))
        {
            _attachedServiceMen.Add(worker);
            if (!worker.Tasks.Contains(this))
            {
                worker.AddTask(this);
            }
        }
    }

    public void DetachWorker(ServiceMan worker)
    {
        ArgumentNullException.ThrowIfNull(worker);
        if (_attachedServiceMen.Remove(worker))
        {
            worker.RemoveTask(this);
        }
    }

    public void AddItemToRepair(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (!_itemsToRepair.Contains(item))
        {
            _itemsToRepair.Add(item);
        }
    }

    public void RemoveItemToRepair(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _itemsToRepair.Remove(item);
    }

    public void MarkAsDone()
    {
        Done = true;
    }

    public override string ToString()
    {
        string str =
            $"Worker Task: {WorkerTaskId}, Name: {Name}, Description: {Description}, Priority: {Priority}, Deadline: {Deadline}, Done: {Done}, Assigned Workers: {string.Join(", ", _attachedServiceMen.Select(w => w.UserId))}";

        if (_itemsToRepair.Count > 0)
        {
            str += $", ItemsToRepair: {string.Join(", ", _itemsToRepair)}";
        }

        return str;
    }

    public static void SetStaticId(long id)
    {
        _id = id;
    }
}