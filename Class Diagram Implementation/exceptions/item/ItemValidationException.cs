namespace BYT_03.exceptions.item;

public class ItemValidationException : Exception
{
    public ItemValidationException(string message) : base(message)
    {
    }
}