using System.Text.Json.Serialization;

namespace BYT_03.entities.Abstract;

public abstract class User
{
    private static long _id = 0;
    public string UserTypeName => GetType().Name;
    public long UserId { get; set; } = ++_id;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }

    [JsonIgnore]
    public int Age
    {
        get => DateTime.Now.Year - BirthDate.Year;
        set => throw new InvalidOperationException("Age is dynamically calculated, you can't set it");
    }

    public static void SetStaticId(long id)
    {
        _id = id;
    }

    public override string ToString()
    {
        return
            $"ID: {UserId}, Name: {Name}, Surname: {Surname}, Phone: {Phone}, Email: {Email}, BirthDate: {BirthDate}, Age: {Age}";
    }
}