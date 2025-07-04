using BYT_03.data;
using BYT_03.entities;
using BYT_03.exceptions.task;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class WorkerTaskServiceTest
{
    private readonly WorkerTaskService _workerTaskService = new WorkerTaskService();

    // private WorkerTask wt = new WorkerTask()
    // {
    //     Name = "WorkerTask",
    //     Description = "Description",
    //     Priority = 5,
    //     Deadline = DateTime.Now,
    //     Done = false,
    //     AttachedWorkersIds = [1, 2],
    //     ItemsToRepair = [3, 4]
    //
    // };
    //
    // [SetUp]
    // public void Setup()
    // {
    //     Storage.LoadData();
    // }
    //
    //
    // [Test]
    // public void AddWTTest_ValidWt()
    // {
    //     int before = _workerTaskService.GetWorkerTasksCount();
    //     _workerTaskService.AddWorkerTask(wt);
    //     
    //     Assert.That(_workerTaskService.GetAllWorkerTasks().Count(), Is.EqualTo(before + 1));
    //     
    //     _workerTaskService.RemoveWorkerTask(wt.WorkerTaskId);
    // }
    //
    // [Test]
    // public void AddWTsTest_ValidWts()
    // {
    //     var wts = new List<WorkerTask>
    //     {
    //         new WorkerTask()
    //         {
    //             Name = "WorkerTask1",
    //             Description = "Description1",
    //             Priority = 3,
    //             Deadline = DateTime.Now,
    //             Done = false,
    //             AttachedWorkersIds = [4, 2],
    //             ItemsToRepair = [5, 6]
    //             
    //         },
    //         new WorkerTask()
    //         {
    //             Name = "WorkerTask2",
    //             Description = "Description2",
    //             Priority = 2,
    //             Deadline = DateTime.Now,
    //             Done = false,
    //             AttachedWorkersIds = [3, 2],
    //             ItemsToRepair = [5, 4]
    //             
    //         }
    //     };
    //     
    //     int before = _workerTaskService.GetWorkerTasksCount();
    //     _workerTaskService.AddWorkerTasks(wts);
    //     
    //     Assert.That(_workerTaskService.GetAllWorkerTasks().Count(), Is.EqualTo(before + 2));
    //     
    //     _workerTaskService.RemoveWorkerTask(wts[0].WorkerTaskId);
    //     _workerTaskService.RemoveWorkerTask(wts[1].WorkerTaskId);
    //     
    // }
    //
    //
    // [Test]
    // public void GetWTTest_ValidWtId()
    // {
    //     _workerTaskService.AddWorkerTask(wt);
    //     
    //     Assert.That(_workerTaskService.GetWorkerTaskById(wt.WorkerTaskId), Is.EqualTo(wt));
    //     
    //     _workerTaskService.RemoveWorkerTask(wt.WorkerTaskId);
    // }
    //
    // [Test]
    // public void GetWTTest_InvalidWtId()
    // {
    //     Assert.Throws<WorkerTaskNotFoundException>(() => _workerTaskService.GetWorkerTaskById(wt.WorkerTaskId));
    // }
    //
    //
    // [Test]
    // public void RemoveWtTest_ValidWtId()
    // {
    //     _workerTaskService.AddWorkerTask(wt);
    //     _workerTaskService.RemoveWorkerTask(wt.WorkerTaskId);
    //     
    //     Assert.Throws<WorkerTaskNotFoundException>(() => _workerTaskService.GetWorkerTaskById(wt.WorkerTaskId));
    // }
    //
    //
    // [Test]
    // public void RemoveWtTest_InvalidWtId()
    // {
    //     Assert.Throws<WorkerTaskNotFoundException>(() => _workerTaskService.RemoveWorkerTask(wt.WorkerTaskId));
    // }
    //
    //
    // [Test]
    // public void GetWtCountTest()
    // {
    //     Assert.IsNotNull(_workerTaskService.GetWorkerTasksCount());
    // }
    //
    //
    // [Test]
    // public void GetWtCountTest_Empty()
    // {
    //     var wts = _workerTaskService.GetAllWorkerTasks();
    //
    //     foreach (KeyValuePair<long, WorkerTask> task in wts)
    //     {
    //         _workerTaskService.RemoveWorkerTask(task.Key);
    //     }
    //     
    //     Assert.That(_workerTaskService.GetWorkerTasksCount(), Is.EqualTo(0));
    //     
    //     _workerTaskService.AddWorkerTasks([..wts.Values]);
    // }
    //
    //
    // [Test]
    // public void GetAllWtsTest()
    // {
    //     Assert.That(_workerTaskService.GetAllWorkerTasks().Count(), Is.EqualTo(_workerTaskService.GetWorkerTasksCount()));
    // }
}