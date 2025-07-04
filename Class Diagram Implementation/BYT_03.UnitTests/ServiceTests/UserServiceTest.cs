using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions.user;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class UserServiceTest
{
    private readonly UserService _userService = new();

    [SetUp]
    public void Setup()
    {
        Storage.LoadData();
    }


    [Test]
    public void AddUserTest_ValidUser()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
        };

        int before = _userService.GetAllUsers().Count();
        _userService.AddUser(user);
        
        Assert.That(_userService.GetAllUsers().Count, Is.EqualTo(before + 1));
        
        _userService.RemoveUser(user.UserId);
    }


    [Test]
    public void AddUsersTest_ValidUsers()
    {
        var users = new List<User>
        {
            new Worker()
            {
                Name = "John",
                Surname = "Smith",
                Phone = "123456789",
                Email = "john.smith@gmail.com",
                BirthDate = new DateOnly(2004, 10, 10),
                HireDate = new DateOnly(2023, 10, 10),
                Salary = 1000
            },
            new Worker()
            {
                Name = "Johnny",
                Surname = "Smithson",
                Phone = "987654321",
                Email = "johnny.smithson@gmail.com",
                BirthDate = new DateOnly(2003, 10, 10),
                HireDate = new DateOnly(2022, 10, 10),
                Salary = 2000
            }
        };
        
        int before = _userService.GetAllUsers().Count;
        _userService.AddUsers(users);
        
        Assert.That(_userService.GetAllUsers().Count, Is.EqualTo(before + 2));
        
        _userService.RemoveUser(users[0].UserId);
        _userService.RemoveUser(users[1].UserId);
    }




    [Test]
    public void GetUserTest_ValidUserId()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
        };
        
        _userService.AddUser(user);
        
        Assert.That(_userService.GetUserById(user.UserId), Is.EqualTo(user));
        
        _userService.RemoveUser(user.UserId);
    }
    
    [Test]
    public void GetUserTest_InvalidUserId()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
        };
        
        Assert.Throws<UserNotFoundException>(() => _userService.GetUserById(user.UserId));
    }


    [Test]
    public void RemoveUserTest_ValidUserId()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
        };
        
        _userService.AddUser(user);
        _userService.RemoveUser(user.UserId);
        
        Assert.Throws<UserNotFoundException>(() => _userService.GetUserById(user.UserId));
        
    }
    
    [Test]
    public void RemoveUserTest_InvalidUserId()
    {
        var user = new Worker();
        
        Assert.Throws<UserNotFoundException>(() => _userService.RemoveUser(user.UserId));
        
    }

    
    [Test]
    public void GetUsersCountTest()
    {
        var count = _userService.GetUsersCount();
        
        Assert.IsNotNull(count);
    }


    // [Test]
    // public void GetUsersCountTest_Empty()
    // {
    //     var users = _userService.GetAllUsers();
    //
    //     foreach (KeyValuePair<long, User> user in users)
    //     {
    //         _userService.RemoveUser(user.Key);
    //     }
    //     
    //     Assert.That(_userService.GetUsersCount(), Is.EqualTo(0));
    //     
    //     if(users.Count > 0)
    //         _userService.AddUsers([..users.Values]);
    // }

    [Test]
    public void GetAllUsersTest()
    {
        Assert.That(_userService.GetAllUsers().Count(), Is.EqualTo(_userService.GetUsersCount()));
    }
    
}