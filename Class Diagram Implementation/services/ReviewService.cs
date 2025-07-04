using BYT_03.data;
using BYT_03.entities;
using BYT_03.entities.Abstract;
using BYT_03.exceptions;
using BYT_03.exceptions.item;
using BYT_03.exceptions.review;

namespace BYT_03.services;

public class ReviewService
{
    public void AddReview(Review review)
    {
        if (review.Rate is < 1 or > 5)
        {
            throw new ArgumentException("Rate must be between 1 and 5.");
        }

        if (review.Client.UserId <= 0)
        {
            throw new ArgumentException("ClientId must be a positive number.");
        }

        if (review.Item.ItemId <= 0)
        {
            throw new ArgumentException("ItemId must be a positive number.");
        }

        Storage.Reviews.Remove(review.ReviewId);

        Storage.Reviews.Add(review.ReviewId, review);
        Storage.SaveChanges();
    }

    public void AddReviews(List<Review> items)
    {
        foreach (var item in items)
        {
            AddReview(item);
        }

        // Storage.SaveChanges();
    }

    public Review GetReviewById(long id)
    {
        if (Storage.Reviews.ContainsKey(id))
        {
            return new Review(Storage.Reviews[id]);
        }

        throw new ReviewNotFoundException($"Item with id {id} not found");
    }

    public int GetReviewsCount()
    {
        return Storage.Reviews.Count;
    }

    public void RemoveReview(long id)
    {
        if (Storage.Reviews.ContainsKey(id))
        {
            Storage.Reviews.Remove(id);
            Storage.SaveChanges();
            return;
        }

        throw new ReviewNotFoundException($"Item with id {id} not found");
    }

    public Dictionary<long, Review> GetAllReviews()
    {
        return Storage.Reviews.ToDictionary(idReview => idReview.Key,
            idReview => new Review(idReview.Value));
    }
}