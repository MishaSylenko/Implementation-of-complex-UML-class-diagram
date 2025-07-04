using BYT_03.entities.Abstract;

namespace BYT_03.entities;

[Serializable]
public class Worker : User
{
    public DateOnly HireDate { get; set; }
    public int Salary { get; set; }


    public Worker()
    {
    }

    public Worker(string name, string surname, string phone, string email, DateOnly birthDate, DateOnly hireDate,
        int salary)
    {
        Name = name;
        Surname = surname;
        Phone = phone; 
        Email = email;
        BirthDate = birthDate;
        HireDate = hireDate;
        Salary = salary;
    }

    public Worker(Worker worker)
    {
        Name = worker.Name;
        Surname = worker.Surname;
        Phone = worker.Phone;
        Email = worker.Email;
        BirthDate = worker.BirthDate;
        HireDate = worker.HireDate;
        Salary = worker.Salary;
    }
    


    public override string ToString()
    {
        return
            $"Worker: {UserId}, {Name}, {Surname}, {Phone}, {Email}, BirthDate: {BirthDate}, HireDate: {HireDate}, Salary: {Salary}";
    }
}