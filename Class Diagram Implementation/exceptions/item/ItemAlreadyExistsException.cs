namespace BYT_03.exceptions.item;

public class ItemAlreadyExistsException : Exception
{
    public ItemAlreadyExistsException(string message) : base(message)
    {
    }
}