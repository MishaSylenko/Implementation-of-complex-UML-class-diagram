using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions;
using BYT_03.exceptions.item;
using BYT_03.exceptions.user;
using BYT_03.services;

namespace BYT_03.UnitTests;

public class Tests
{
    private readonly ItemService _itemService = new ItemService();
    private readonly UserService _userService = new UserService();
    private readonly WorkerTaskService _workerTaskService = new WorkerTaskService();
    private readonly OrderService _orderService = new OrderService();
    private readonly ReviewService _reviewService = new ReviewService();

    [SetUp]
    public void Setup()
    {
        Storage.LoadData();
    }


    [Test]
    public void TestItemNotFound()
    {
        Assert.Throws<ItemNotFoundException>(() => _itemService.GetItemById(99999));
    }

    [Test]
    public void TestUserNotFound()
    {
        Assert.Throws<UserNotFoundException>(() => _userService.GetUserById(99999));
    }


    // [Test]
    // public void TestUpdateTaskStatus()
    // {
    //     var task = new WorkerTask
    //     {
    //         Name = "Task",
    //         Description = "Description",
    //         Priority = 5,
    //         Deadline = DateTime.Now,
    //         Done = false,
    //         AttachedWorkersIds = [1],
    //         ItemsToRepair = [1]
    //     };
    //     _workerTaskService.AddWorkerTask(task);
    //     _workerTaskService.GetWorkerTaskById(task.WorkerTaskId);
    //     _workerTaskService.SetTaskDoneStatus(task.WorkerTaskId, true);
    //
    //     Assert.That(_workerTaskService.GetWorkerTaskById(task.WorkerTaskId).Done, Is.True);
    //     _workerTaskService.RemoveWorkerTask(task.WorkerTaskId);
    // }
}