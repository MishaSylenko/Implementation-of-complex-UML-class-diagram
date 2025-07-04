using BYT_03.data;
using BYT_03.entities;
using BYT_03.exceptions;
using BYT_03.exceptions.review;
using BYT_03.services;

namespace BYT_03.UnitTests;
[TestFixture]
public class ReviewServiceTests
{
    // ReviewService _reviewService = new ReviewService();
    // Review _review = new Review()
    // {
    //     ClientId = 1,
    //     ItemId = 1,
    //     Rate = 5,
    //     Description = "Comment"
    // };
    //         
    // [SetUp]
    // public void Setup()
    // {
    //     Storage.LoadData();
    // }
    //
    // [Test]
    // public void AddOrderTest_ValidOrder()
    // {
    //     _reviewService.AddReview(_review);
    //     Assert.That(Storage.Reviews, Has.Count.EqualTo(1));
    //     _reviewService.RemoveReview(_review.ReviewId);
    // }
    //
    // [Test]
    // public void AddOrdersTest_ValidOrders()
    // {
    //     _reviewService.AddReviews(new List<Review>(){_review});
    //     Assert.That(Storage.Reviews, Has.Count.EqualTo(1));
    //     _reviewService.RemoveReview(_review.ReviewId);
    // }
    //
    // [Test]
    // public void GetOrderByIdTest_OrderExists()
    // {
    //     _reviewService.AddReview(_review);
    //     var review = _reviewService.GetReviewById(_review.ReviewId);
    //     Assert.That(review, Is.Not.Null);
    //     _reviewService.RemoveReview(_review.ReviewId);
    // }
    //
    // [Test]
    // public void GetOrderByIdTest_OrderDoesNotExist()
    // {
    //     Assert.Throws<ReviewNotFoundException>(() => _reviewService.GetReviewById(99999));
    // }
    //
    // [Test]
    // public void RemoveOrderTest_OrderExists()
    // {
    //     _reviewService.AddReview(_review);
    //     _reviewService.RemoveReview(_review.ReviewId);
    //     Assert.That(Storage.Reviews, Has.Count.EqualTo(0));
    // }
    //
    //
    // [Test]
    // public void RemoveOrderTest_OrderDoesNotExist()
    // {
    //     Assert.Throws<ReviewNotFoundException>(() => _reviewService.RemoveReview(99999));
    // }
    //
    // [Test]
    // public void GetOrdersCountTest()
    // {
    //     _reviewService.AddReview(_review);
    //     Assert.That(_reviewService.GetReviewsCount(), Is.EqualTo(1));
    //     _reviewService.RemoveReview(_review.ReviewId);
    // }
    //
    // [Test]
    // public void GetOrdersCountTest_NoOrders()
    // {
    //     Assert.That(_reviewService.GetReviewsCount(), Is.EqualTo(0));
    // } 
    //
    // [Test]
    // public void GetAllOrdersTest()
    // {
    //     _reviewService.AddReview(_review);
    //     var reviews = _reviewService.GetAllReviews();
    //     Assert.That(reviews, Has.Count.EqualTo(1));
    //     _reviewService.RemoveReview(_review.ReviewId);
    // }
}