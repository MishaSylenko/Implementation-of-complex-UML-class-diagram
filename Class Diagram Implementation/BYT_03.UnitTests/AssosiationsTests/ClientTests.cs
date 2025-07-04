using BYT_03.entities;

namespace BYT_03.UnitTests.AssosiationsTests;

[TestFixture]
public class ClientTests
{
    [Test]
        public void AddOrderThrowsArgumentNullExceptionOnOrder()
        {
            var client = new Client();
            Assert.Throws<ArgumentNullException>(() => client.AddOrder(null));
        }

        [Test]
        public void AddOrderAddsOrderToClient()
        {
            var client = new Client();
            var order = new Order();
            client.AddOrder(order);

            Assert.IsTrue(client.Orders.ContainsKey(order.OrderId));
            Assert.AreEqual(client, order.Client);
        }

        [Test]
        public void AddFavoriteItemThrowsArgumentNullExceptionOnItem()
        {
            var client = new Client();
            Assert.Throws<ArgumentNullException>(() => client.AddFavoriteItem(null));
        }

        [Test]
        public void AddFavoriteItemAddsItemToFavorites()
        {
            var client = new Client();
            var item = new TestItem();
            client.AddFavoriteItem(item);

            Assert.IsTrue(client.FavoriteItems.Contains(item));
        }

        [Test]
        public void RemoveFavoriteItemThrowsArgumentNullExceptionOnItem()
        {
            var client = new Client();
            Assert.Throws<ArgumentNullException>(() => client.RemoveFavoriteItem(null));
        }

        [Test]
        public void RemoveFavoriteItemRemovesItemFromFavorites()
        {
            var client = new Client();
            var item = new TestItem();
            client.AddFavoriteItem(item);
            client.RemoveFavoriteItem(item);

            Assert.IsFalse(client.FavoriteItems.Contains(item));
        }

        [Test]
        public void AddReviewThrowsArgumentNullExceptionOnItem()
        {
            var client = new Client();
            var review = new Review();
            Assert.Throws<ArgumentNullException>(() => client.AddReview(null, review));
        }

        [Test]
        public void AddReviewThrowsArgumentNullExceptionOnReview()
        {
            var client = new Client();
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => client.AddReview(item, null));
        }

        [Test]
        public void AddReviewAddsReviewToItem()
        {
            var client = new Client();
            var item = new TestItem();
            var review = new Review();
            client.AddReview(item, review);

            Assert.IsTrue(client.Reviews.Contains(review));
            Assert.IsTrue(item.Reviews.Contains(review));
        }

        [Test]
        public void RemoveReviewThrowsArgumentNullExceptionOnItem()
        {
            var client = new Client();
            var review = new Review();
            Assert.Throws<ArgumentNullException>(() => client.RemoveReview(null, review));
        }

        [Test]
        public void RemoveReviewThrowsArgumentNullExceptionOnReview()
        {
            var client = new Client();
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => client.RemoveReview(item, null));
        }

        [Test]
        public void RemoveReviewRemovesReviewFromItem()
        {
            var client = new Client()
            {
                Name = "Test",
                Surname = "Test",
                Phone = "Test",
                Email = "Test",
                BirthDate = new DateOnly(2000, 1, 1),
                UserId = 1

            };
            var item = new TestItem();
            var review = new Review();
            client.AddReview(item, review);
            client.RemoveReview(item, review);

            Assert.IsFalse(client.Reviews.Contains(review));
            Assert.IsFalse(item.Reviews.Contains(review));
        }
}