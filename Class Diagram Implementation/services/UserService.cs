using System.Text.RegularExpressions;
using BYT_03.data;
using BYT_03.entities.Abstract;
using BYT_03.exceptions.user;

namespace BYT_03.services;

public class UserService
{
    public void AddUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
        {
            throw new ArgumentException("Invalid user name");
        }

        if (string.IsNullOrWhiteSpace(user.Surname))
        {
            throw new ArgumentException("Invalid user surname");
        }

        if (string.IsNullOrWhiteSpace(user.Phone) || user.Phone.Length < 9)
        {
            throw new ArgumentException("Invalid user phone");
        }

        //the regex is from internal code of EmailAddressAttribute.cs
        if (user.Email == null || !Regex.IsMatch(user.Email,
                @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$",
                RegexOptions.IgnoreCase))
        {
            throw new ArgumentException("Invalid user email");
        }

        if (user.BirthDate == null || user.Age <= 0)
        {
            throw new ArgumentException("Invalid user birth date");
        }

        Storage.Users.Add(user.UserId, user);
        Storage.SaveChanges();
    }

    public void AddUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Storage.Users.Add(user.UserId, user);
        }

        Storage.SaveChanges();
    }

    public User GetUserById(long id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid user id");
        }

        if (Storage.Users.ContainsKey(id))
        {
            return Storage.Users[id];
        }

        throw new UserNotFoundException($"User with id {id} not found");
    }

    public int GetUsersCount()
    {
        return Storage.Users.Count;
    }

    public void RemoveUser(long id)
    {
        if (Storage.Users.ContainsKey(id))
        {
            Storage.Users.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new UserNotFoundException($"User with id {id} not found");
    }

    public Dictionary<long, User> GetAllUsers()
    {
        var users = Storage.Users.ToDictionary(user => user.Key, user => user.Value);
        return users;
    }
}