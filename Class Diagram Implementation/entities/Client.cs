using BYT_03.entities.Abstract;

namespace BYT_03.entities;

[Serializable()]
public class Client : User
{
    public static int NumberOfClients { get; private set; } = 0;

    public string Address { get; set; }
    public string ShippingAddress { get; set; }

    private readonly List<string> _cards = new();
    public IReadOnlyList<string> Cards => _cards.AsReadOnly();

    public Dictionary<long, Order> Orders = new();

    private readonly List<Item> _favoriteItems = new();
    public IReadOnlyList<Item> FavoriteItems => _favoriteItems.AsReadOnly();

    private readonly List<Review> _reviews = new();
    public IReadOnlyList<Review> Reviews => _reviews.AsReadOnly();

    public Client()
    {
        NumberOfClients++;
    }

    public Client(Client client) : this()
    {
        Name = client.Name;
        Surname = client.Surname;
        Phone = client.Phone;
        Email = client.Email;
        BirthDate = client.BirthDate;
        Address = client.Address;
        ShippingAddress = client.ShippingAddress;
        _cards.AddRange(client._cards);
        _favoriteItems.AddRange(client._favoriteItems);
        _reviews.AddRange(client._reviews);
    }

    public void AddCard(string card)
    {
        ArgumentNullException.ThrowIfNull(card);
        _cards.Add(card);
    }

    public void RemoveCard(string card)
    {
        ArgumentNullException.ThrowIfNull(card);
        _cards.Remove(card);
    }

    public void AddOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        if (!Orders.ContainsKey(order.OrderId))
        {
            Orders.Add(order.OrderId, order);
            if (order.Client != this)
            {
                order.AttachUser(this);
            }
        }
    }

    public void AddFavoriteItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (!_favoriteItems.Contains(item))
        {
            _favoriteItems.Add(item);
            item.AddToFavorites(this);
        }
    }

    public void RemoveFavoriteItem(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (_favoriteItems.Remove(item))
        {
            item.RemoveFromFavorites(this);
        }
    }

    public void AddReview(Item item, Review review)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        ArgumentNullException.ThrowIfNull(review, nameof(review));

        review.AssignClient(this);

        _reviews.Add(review);

        item.AddReview(review, this);
    }

    public void RemoveReview(Item item, Review review)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        ArgumentNullException.ThrowIfNull(review, nameof(review));

        if (_reviews.Remove(review))
        {
            item.RemoveReview(review, this);

            review.removeClient();
        }
    }


    public override string ToString()
    {
        return base.ToString() +
               $", Address: {Address}, ShippingAddress: {ShippingAddress}, Cards: {string.Join(",", Cards)}, Favorite Items: {string.Join(",", FavoriteItems)}";
    }
}
