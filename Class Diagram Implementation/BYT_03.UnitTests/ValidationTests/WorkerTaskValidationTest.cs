using BYT_03.data;
using BYT_03.entities;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class WorkerTaskValidationTest
{
    private readonly WorkerTaskService _workerTaskService = new WorkerTaskService();
    
    
    [SetUp]
    public void Setup()
    {
        Storage.LoadData();
    }


    // [Test]
    // public void ValidationTest_InvalidName()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "    ",
    //         Description = "Description",
    //         Priority = 5,
    //         Deadline = DateTime.Now,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex.Message, Is.EqualTo("Invalid worker task name"));
    //
    // }
    //
    // [Test]
    // public void ValidationTest_InvalidDescription()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "     ",
    //         Priority = 5,
    //         Deadline = DateTime.Now,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex.Message, Is.EqualTo("Invalid worker task description"));
    //
    // }
    //
    // [Test]
    // public void ValidationTest_NullPriority()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "Description",
    //         Deadline = DateTime.Now,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex.Message, Is.EqualTo("Invalid worker task priority"));
    //
    // }
    //
    // [Test]
    // public void ValidationTest_PriorityOverTen()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "Description",
    //         Deadline = DateTime.Now,
    //         Priority = 100,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex.Message, Is.EqualTo("Invalid worker task priority"));
    //
    // }
    //
    // [Test]
    // public void ValidationTest_NegativePriority()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "Description",
    //         Deadline = DateTime.Now,
    //         Priority = -1,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex?.Message, Is.EqualTo("Invalid worker task priority"));
    // }
    //
    // [Test]
    // public void ValidationTest_InvalidAttachedWorkersIds()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "Description",
    //         Deadline = DateTime.Now,
    //         Priority = 5,
    //         Done = false,
    //         AttachedWorkersIds = [-1, 2],
    //         ItemsToRepair = [3, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex?.Message, Is.EqualTo("Invalid worker task attached workers ids"));
    // }
    //
    // [Test]
    // public void ValidationTest_InvalidItemsToRepairIds()
    // {
    //     var wt = new WorkerTask()
    //     {
    //         Name = "WorkerTask",
    //         Description = "Description",
    //         Deadline = DateTime.Now,
    //         Priority = 5,
    //         Done = false,
    //         AttachedWorkersIds = [1, 2],
    //         ItemsToRepair = [-13, 4]
    //     };
    //
    //     var ex = Assert.Throws<ArgumentException>(() => _workerTaskService.AddWorkerTask(wt));
    //     Assert.That(ex.Message, Is.EqualTo("Invalid worker task items to repair ids"));
    //
    // }
}