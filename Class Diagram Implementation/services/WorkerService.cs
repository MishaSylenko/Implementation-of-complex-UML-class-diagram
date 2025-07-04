using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions.user;

namespace BYT_03.services;

public class WorkerService
{
    public void RemoveServiceMan(long id)
    {
        if (Storage.Users.ContainsKey(id))
        {
            ServiceMan foundWorker = (ServiceMan)Storage.Users[id];
            IReadOnlyList<WorkerTask> workerTasks = foundWorker.Tasks;
            foreach (var workerTask in workerTasks)
            {
                foundWorker.RemoveTask(workerTask);
                Storage.WorkerTasks.Remove(workerTask.WorkerTaskId);
            }

            Storage.Users.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new UserNotFoundException($"User with id {id} not found");
    }

    public void ChangeRoleToInfolineOperator(int userId, TimeOnly newShiftStartTime, TimeOnly newShiftEndTime)
    {
        if (Storage.Users.ContainsKey(userId))
        {
            var worker = (Worker)Storage.Users[userId];

            if (worker is ServiceMan)
            {
                var infoLineOperator = new InfolineOperator(worker, newShiftStartTime, newShiftEndTime);
                Storage.Users[userId] = infoLineOperator;
            }
            else
            {
                throw new InvalidOperationException("Role change is not supported for the current worker type.");
            }
        }
        else
        {
            throw new KeyNotFoundException("The worker with the specified ID does not exist.");
        }
    }
}