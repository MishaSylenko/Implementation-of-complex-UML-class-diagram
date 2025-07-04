using BYT_03.data;
using BYT_03.entities;
using BYT_03.services;

namespace BYT_03.UnitTests;

[TestFixture]
public class UserValidationTest
{
    private readonly UserService _userService = new UserService();
    
    [SetUp]
    public void Setup()
    {
        Storage.LoadData();
    }


    [Test]
    public void ValidationTest_InvalidName()
    {
        var user = new Worker()
        {
            Name = "    ",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user name"));
    }
    
    [Test]
    public void ValidationTest_InvalidSurName()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "     ",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user surname"));
    }
    
    [Test]
    public void AddUserValidationTest_InvalidPhoneLength()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "1234",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user phone"));
    }
    
    [Test]
    public void AddUserValidationTest_InvalidPhone()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "   ",
            Email = "john.smith@gmail.com",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user phone"));
    }
    
    [Test]
    public void ValidationTest_NullEmail()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = null,
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user email"));
    }
    
    [Test]
    public void ValidationTest_InvalidEmail()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "email",
            BirthDate = new DateOnly(2004, 10, 10),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user email"));
    }
    
    [Test]
    public void AddUserValidationTest_InvalidBirthDate()
    {
        var user = new Worker()
        {
            Name = "John",
            Surname = "Smith",
            Phone = "123456789",
            Email = "john.smith@gmail.com",
            BirthDate = DateOnly.FromDateTime(DateTime.Today),
            HireDate = new DateOnly(2023, 10, 10),
            Salary = 1000
            
        };
        
        var ex = Assert.Throws<ArgumentException>(() => _userService.AddUser(user));
        Assert.That(ex.Message, Is.EqualTo("Invalid user birth date"));
    }
}