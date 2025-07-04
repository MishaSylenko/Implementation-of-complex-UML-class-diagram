using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.enums;
using BYT_03.exceptions.user;
using BYT_03.services;

namespace BYT_03.UnitTests.InheritanceTests;

public class WorkerTests
{
    private WorkerService _workerService;
    private UserService _userService;

    [SetUp]
    public void SetUp()
    {
        _workerService = new WorkerService();
        _userService = new UserService();
    }

    [Test]
    public void ChangeRoleToInfolineOperator_ValidRoleChange_UpdatesWorkerRole()
    {
        var worker = new Worker("John", "Doe", "123456789", "john.doe@example.com",
            new DateOnly(1990, 5, 10), new DateOnly(2020, 1, 1), 3000);
        var serviceMan = new ServiceMan(worker, JobType.FIXING_ITEMS);
        _userService.AddUser(serviceMan);

        int userId = (int)serviceMan.UserId;
        var newShiftStartTime = new TimeOnly(9, 0);
        var newShiftEndTime = new TimeOnly(17, 0);

        _workerService.ChangeRoleToInfolineOperator(userId, newShiftStartTime, newShiftEndTime);

        var updatedWorker = _userService.GetUserById(userId);
        Assert.IsInstanceOf<InfolineOperator>(updatedWorker);
        var infoLineOperator = (InfolineOperator)updatedWorker;
        Assert.That(infoLineOperator.ShiftStart, Is.EqualTo(newShiftStartTime));
        Assert.That(infoLineOperator.ShiftEnd, Is.EqualTo(newShiftEndTime));
    }

    [Test]
    public void ChangeRoleToInfolineOperator_WorkerNotFound_ThrowsKeyNotFoundException()
    {
        int nonExistentUserId = 999; 
        var newShiftStartTime = new TimeOnly(9, 0);
        var newShiftEndTime = new TimeOnly(17, 0);

        var ex = Assert.Throws<KeyNotFoundException>(() =>
            _workerService.ChangeRoleToInfolineOperator(nonExistentUserId, newShiftStartTime, newShiftEndTime));
        Assert.AreEqual("The worker with the specified ID does not exist.", ex.Message);
    }

    [Test]
    public void ChangeRoleToInfolineOperator_InvalidWorkerType_ThrowsInvalidOperationException()
    {
        var worker = new Worker("John", "Doe", "123456789", "john.doe@example.com",
            new DateOnly(1990, 5, 10), new DateOnly(2020, 1, 1), 3000);
        var serviceMan = new InfolineOperator(worker, new TimeOnly(9, 0), new TimeOnly(17, 0));
        _userService.AddUser(serviceMan);

        var ex = Assert.Throws<InvalidOperationException>(() =>
            _workerService.ChangeRoleToInfolineOperator((int)serviceMan.UserId, new TimeOnly(9, 0),
                new TimeOnly(17, 0)));
        Assert.AreEqual("Role change is not supported for the current worker type.", ex.Message);
    }
}