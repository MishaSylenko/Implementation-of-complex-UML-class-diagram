namespace BYT_03.exceptions.general;

public class NotUniqueIdException : Exception
{
    public NotUniqueIdException(string message) : base(message)
    {
    }
}