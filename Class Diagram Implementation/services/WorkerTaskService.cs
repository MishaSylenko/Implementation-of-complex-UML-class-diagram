using BYT_03.data;
using BYT_03.entities;
using BYT_03.exceptions.task;

namespace BYT_03.services;

public class WorkerTaskService
{
    public void AddWorkerTask(WorkerTask workerTask)
    {
        if (string.IsNullOrWhiteSpace(workerTask.Name))
        {
            throw new ArgumentException("Invalid worker task name");
        }

        if (string.IsNullOrWhiteSpace(workerTask.Description))
        {
            throw new ArgumentException("Invalid worker task description");
        }

        if (workerTask.AttachedServiceMen == null || workerTask.AttachedServiceMen.Count == 0)
        {
            throw new ArgumentException("Invalid worker task attached workers list");
        }

        if (workerTask.AttachedServiceMen.Any(worker => worker.UserId <= 0))
        {
            throw new ArgumentException("Invalid worker task attached workers ids");
        }

        if (workerTask.ItemsToRepair != null && workerTask.AttachedServiceMen.Count == 0)
        {
            throw new ArgumentException("Invalid worker task items to repair list");
        }

        if (workerTask.ItemsToRepair != null && workerTask.ItemsToRepair.Any(item => item.ItemId <= 0))
        {
            throw new ArgumentException("Invalid worker task items to repair ids");
        }

        if (workerTask.Priority is < 1 or > 5)
        {
            throw new ArgumentException("Invalid worker task priority");
        }

        Storage.WorkerTasks.Add(workerTask.WorkerTaskId, workerTask);
        Storage.SaveChanges();
    }

    public void AddWorkerTasks(List<WorkerTask> workerTasks)
    {
        foreach (var workerTask in workerTasks)
        {
            Storage.WorkerTasks.Add(workerTask.WorkerTaskId, workerTask);
        }

        Storage.SaveChanges();
    }

    public WorkerTask GetWorkerTaskById(long id)
    {
        if (Storage.WorkerTasks.ContainsKey(id))
        {
            return Storage.WorkerTasks[id];
        }

        throw new WorkerTaskNotFoundException($"WorkerTask with id {id} not found");
    }

    public int GetWorkerTasksCount()
    {
        return Storage.WorkerTasks.Count;
    }

    public void SetTaskDoneStatus(long id, bool done)
    {
        if (Storage.WorkerTasks.ContainsKey(id))
        {
            Storage.WorkerTasks[id].MarkAsDone();
            Storage.SaveChanges();
        }
        else
        {
            throw new WorkerTaskNotFoundException($"WorkerTask with id {id} not found");
        }
    }

    public void RemoveWorkerTask(long id)
    {
        if (Storage.WorkerTasks.ContainsKey(id))
        {
            Storage.WorkerTasks.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new WorkerTaskNotFoundException($"WorkerTask with id {id} not found");
    }

    public Dictionary<long, WorkerTask> GetAllWorkerTasks()
    {
        var workerTasks =
            Storage.WorkerTasks.ToDictionary(workerTask => workerTask.Key, workerTask => workerTask.Value);
        return workerTasks;
    }
}