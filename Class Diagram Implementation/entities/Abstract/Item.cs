using System.Text.Json.Serialization;

namespace BYT_03.entities.Abstract;

public abstract class Item
{
    private static long _id = 0;

    public long ItemId { get; } = ++_id;
    public string ItemTypeName => GetType().Name;
    public string Name { get; init; }
    public double Price { get; init; }
    public string Brand { get; init; }
    public string Description { get; init; }
    public int InStock { get; init; }

    [JsonIgnore] private readonly List<Client> _addedToFavorites = new();
    [JsonIgnore] public IReadOnlyList<Client> AddedToFavorites => _addedToFavorites.AsReadOnly();

    private readonly List<Review> _reviews = new();
    public IReadOnlyList<Review> Reviews => _reviews.AsReadOnly();

    private readonly List<WorkerTask> _workerTasks = [];

    public IReadOnlyList<WorkerTask> WorkerTasks => _workerTasks.AsReadOnly();

    private List<Order> _orders = [];

    public IReadOnlyList<Order> Orders => _orders.AsReadOnly();

    public static void SetStaticId(long id)
    {
        _id = id;
    }

    public void AddWorkerTask(WorkerTask workerTask)
    {
        ArgumentNullException.ThrowIfNull(workerTask);
        if (!_workerTasks.Contains(workerTask))
        {
            _workerTasks.Add(workerTask);
            if (!workerTask.ItemsToRepair.Contains(this))
            {
                workerTask.AddItemToRepair(this);
            }
        }
    }

    public void RemoveWorkerTask(WorkerTask workerTask)
    {
        ArgumentNullException.ThrowIfNull(workerTask);
        _workerTasks.Remove(workerTask);
        workerTask.RemoveItemToRepair(this);
    }

    public void AddOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        if (!_orders.Contains(order))
        {
            _orders.Add(order);
        }
    }

    public void RemoveOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        _orders.Remove(order);
    }

    public void AddToFavorites(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);
        if (!_addedToFavorites.Contains(client))
        {
            _addedToFavorites.Add(client);
        }
    }

    public void RemoveFromFavorites(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _addedToFavorites.Remove(client);
    }

    public void AddReview(Review review, Client client)
    {
        ArgumentNullException.ThrowIfNull(review);
        ArgumentNullException.ThrowIfNull(client);

        if (!_reviews.Contains(review))
        {
            _reviews.Add(review);
        }
    }

    public void RemoveReview(Review review, Client client)
    {
        ArgumentNullException.ThrowIfNull(review);
        _reviews.Remove(review);
    }

    public override string ToString()
    {
        return
            $"ID: {ItemId}, Name: {Name}, Price: {Price}, Brand: {Brand}, Description: {Description}, InStock: {InStock}";
    }
}