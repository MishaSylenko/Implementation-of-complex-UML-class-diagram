using NUnit.Framework;
using System;
using BYT_03.data;
using BYT_03.entities;
using BYT_03.services;

[TestFixture]
public class ReviewValidationTests
{

    private readonly ReviewService _reviewService = new ReviewService();

    // [Test]
    // public void ValidationRateLessThan1()
    // {
    //     const int invalidRate = 0;
    //     const string description = "Bad product!";
    //     const long clientId = 123;  
    //     const long itemId = 456;
    //
    //     var review = new Review()
    //     {
    //         Rate = invalidRate,
    //         Description = description,
    //         ClientId = clientId,
    //         ItemId = itemId
    //     };
    //     var ex = Assert.Throws<ArgumentException>(() => _reviewService.AddReview(review));
    //     Assert.That(ex.Message, Is.EqualTo("Rate must be between 1 and 5."));
    // }
    //
    // [Test]
    // public void ValidationRateGreaterThan5()
    // {
    //     const int invalidRate = 9;
    //     const string description = "Bad product!";
    //     const long clientId = 123;
    //     const long itemId = 456;
    //
    //     var review = new Review()
    //     {
    //         Rate = invalidRate,
    //         Description = description,
    //         ClientId = clientId,
    //         ItemId = itemId
    //     };
    //     var ex = Assert.Throws<ArgumentException>(() => _reviewService.AddReview(review));
    //     Assert.That(ex.Message, Is.EqualTo("Rate must be between 1 and 5."));
    // }
    //
    // [Test]
    // public void ValidationClientIdNotPositive()
    // {
    //     const int rate = 5;
    //     const string description = "Bad product!";
    //     const long invalidClientId = -1;
    //     const long itemId = 456;
    //
    //     var review = new Review()
    //     {
    //         Rate = rate,
    //         Description = description,
    //         ClientId = invalidClientId,
    //         ItemId = itemId
    //     };
    //     var ex = Assert.Throws<ArgumentException>(() => _reviewService.AddReview(review));
    //     Assert.That(ex.Message, Is.EqualTo("ClientId must be a positive number."));
    // }
    //
    // [Test]
    // public void ValidationItemIdNotPositive()
    // {
    //     const int rate = 5;
    //     const string description = "Bad product!";
    //     const long clientId = 123;
    //     const long invalidItemId = -10;
    //
    //     var review = new Review()
    //     {
    //         Rate = rate,
    //         Description = description,
    //         ClientId = clientId,
    //         ItemId = invalidItemId
    //     };
    //     var ex = Assert.Throws<ArgumentException>(() => _reviewService.AddReview(review));
    //     Assert.That(ex.Message, Is.EqualTo("ItemId must be a positive number."));
    // }
    }