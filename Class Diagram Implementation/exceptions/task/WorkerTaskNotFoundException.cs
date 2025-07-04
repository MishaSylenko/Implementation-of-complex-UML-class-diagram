namespace BYT_03.exceptions.task;

public class WorkerTaskNotFoundException : Exception
{
    public WorkerTaskNotFoundException(string message) : base(message)
    {
    }
}