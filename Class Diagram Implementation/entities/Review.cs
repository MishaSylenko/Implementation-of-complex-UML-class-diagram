using BYT_03.entities.Abstract;

namespace BYT_03.entities;

public class Review
{
    private static long _id = 0;

    public long ReviewId { get; private set; } = ++_id;
    public int Rate { get;  set; }
    public string Description { get;  set; }
    public Client? Client { get; private set; }
    public Item Item { get; private set; }

    public Review() { }
    

    public Review(Review review)
    {
        ReviewId = review.ReviewId;
        Rate = review.Rate;
        Description = review.Description;
        Client = review.Client;
        Item = review.Item;
    }
    
    public void AssignClient(Client? client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));
        Client = client;
    }
    
    public void removeClient()
    {
        Client = null;
    }
    
    public void AssignItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        Item = item;
    }

    public static void SetStaticId(long id)
    {
        _id = id;
    }

    public override string ToString()
    {
        return $"Review: {ReviewId}, Rate: {Rate}, Description: \"{Description}\", ClientId: {Client?.UserId}, Item: {Item}";
    }
}
