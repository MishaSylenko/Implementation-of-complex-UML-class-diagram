using System.Text.Json;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.services;
using BYT_03.services.converters;

namespace BYT_03.data;

public static class Storage
{
    private const string StorageFilePath = "../../../storage.json";

    public static Dictionary<long, Item> Items { get; private set; } = new();

    public static Dictionary<long, Order> Orders { get; private set; } = new();

    public static Dictionary<long, User> Users { get; private set; } = new();

    public static Dictionary<long, Payment> Payments { get; private set; } = new();
    public static Dictionary<long, Review> Reviews { get; private set; } = new();
    public static Dictionary<long, WorkerTask> WorkerTasks { get; private set; } = new();


    public static void SaveChanges()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        
        options.Converters.Add(new ItemConverter());
        options.Converters.Add(new OrderConverter());
        options.Converters.Add(new UserConverter());
        options.Converters.Add(new WorkerTaskConverter());
        options.Converters.Add(new PaymentsConverter());
        options.Converters.Add(new ReviewConverter());

        var jsonData = JsonSerializer.Serialize(new { Items, Orders, Users, WorkerTasks, Payments, Reviews }, options);
        File.WriteAllText(StorageFilePath, jsonData);
    }

    public static void LoadData()
    {
        if (!File.Exists(StorageFilePath))
            return;

        var jsonData = File.ReadAllText(StorageFilePath);
        var options = new JsonSerializerOptions();

        options.Converters.Add(new ItemConverter());
        options.Converters.Add(new OrderConverter());
        options.Converters.Add(new UserConverter());
        options.Converters.Add(new WorkerTaskConverter());
        options.Converters.Add(new PaymentsConverter());
        options.Converters.Add(new ReviewConverter());


        var storageData = JsonSerializer.Deserialize<StorageData>(jsonData, options);
        if (storageData == null) return;
        Items = storageData.Items ?? new Dictionary<long, Item>();
        Orders = storageData.Orders ?? new Dictionary<long, Order>();
        Users = storageData.Users ?? new Dictionary<long, User>();
        WorkerTasks = storageData.WorkerTasks ?? new Dictionary<long, WorkerTask>();
        Payments = storageData.Payments ?? new Dictionary<long, Payment>();
        Reviews = storageData.Reviews ?? new Dictionary<long, Review>();


        Item.SetStaticId(Items.Count == 0 ? 0 : Items.Keys.Max());
        Order.SetStaticId(Orders.Count == 0 ? 0 : Orders.Keys.Max());
        User.SetStaticId(Users.Count == 0 ? 0 : Users.Keys.Max());
        WorkerTask.SetStaticId(WorkerTasks.Count == 0 ? 0 : WorkerTasks.Keys.Max());
        Payment.SetStaticId(Payments.Count == 0 ? 0 : Payments.Keys.Max());
        Review.SetStaticId(Reviews.Count == 0 ? 0 : Reviews.Keys.Max());
    }
}

public class StorageData
{
    public Dictionary<long, Item>? Items { get; init; }
    public Dictionary<long, Order>? Orders { get; init; }
    public Dictionary<long, WorkerTask>? WorkerTasks { get; init; }
    public Dictionary<long, User>? Users { get; init; }
    public Dictionary<long, Payment>? Payments { get; init; }
    public Dictionary<long, Review>? Reviews { get; init; }
    
}