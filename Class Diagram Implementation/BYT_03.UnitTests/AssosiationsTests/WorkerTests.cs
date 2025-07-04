using BYT_03.entities;

namespace BYT_03.UnitTests.AssosiationsTests;

public class WorkerTests
{
    [Test]
    public void AddTaskThrowsArgumentNullExceptionOnTask()
    {
        var worker = new ServiceMan();
        Assert.Throws<ArgumentNullException>(() => worker.AddTask(null));
    }

    [Test]
    public void AddTaskAddsTask()
    {
        var worker = new ServiceMan();
        var task = new WorkerTask();
        worker.AddTask(task);

        Assert.IsTrue(worker.Tasks.Contains(task));
        Assert.IsTrue(task.AttachedServiceMen.Contains(worker));
    }

    [Test]
    public void RemoveTaskThrowsArgumentNullExceptionOnTask()
    {
        var worker = new ServiceMan();
        Assert.Throws<ArgumentNullException>(() => worker.RemoveTask(null));
    }

    [Test]
    public void RemoveTaskRemovesTask()
    {
        var worker = new ServiceMan();
        var task = new WorkerTask();
        worker.AddTask(task);
        worker.RemoveTask(task);

        Assert.IsFalse(worker.Tasks.Contains(task));
        Assert.IsFalse(task.AttachedServiceMen.Contains(worker));
    }
}