using BYT_03.entities;

namespace BYT_03.UnitTests.AssosiationsTests;

[TestFixture]
public class ItemTests
{
        [Test]
        public void AddWorkerTaskThrowsArgumentNullExceptionOnWorkerTask()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.AddWorkerTask(null));
        }

        [Test]
        public void AddWorkerTaskAddsWorkerTask()
        {
            var item = new TestItem();
            var workerTask = new WorkerTask();
            item.AddWorkerTask(workerTask);

            Assert.IsTrue(item.WorkerTasks.Contains(workerTask));
            Assert.IsTrue(workerTask.ItemsToRepair.Contains(item));
        }

        [Test]
        public void RemoveWorkerTaskThrowsArgumentNullExceptionOnWorkerTask()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.RemoveWorkerTask(null));
        }

        [Test]
        public void RemoveWorkerTaskRemovesWorkerTask()
        {
            var item = new TestItem();
            var workerTask = new WorkerTask();
            item.AddWorkerTask(workerTask);
            item.RemoveWorkerTask(workerTask);

            Assert.IsFalse(item.WorkerTasks.Contains(workerTask));
            Assert.IsFalse(workerTask.ItemsToRepair.Contains(item));
        }

        [Test]
        public void AddOrderThrowsArgumentNullExceptionOnOrder()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.AddOrder(null));
        }

        [Test]
        public void AddOrderAddsOrder()
        {
            var item = new TestItem();
            var order = new Order();
            item.AddOrder(order);

            Assert.IsTrue(item.Orders.Contains(order));
        }

        [Test]
        public void RemoveOrderThrowsArgumentNullExceptionOnOrder()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.RemoveOrder(null));
        }

        [Test]
        public void RemoveOrderRemovesOrder()
        {
            var item = new TestItem();
            var order = new Order();
            item.AddOrder(order);
            item.RemoveOrder(order);

            Assert.IsFalse(item.Orders.Contains(order));
        }

        [Test]
        public void AddToFavoritesThrowsArgumentNullExceptionOnClient()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.AddToFavorites(null));
        }

        [Test]
        public void AddToFavoritesAddsClientToFavorites()
        {
            var item = new TestItem();
            var client = new Client();
            item.AddToFavorites(client);

            Assert.IsTrue(item.AddedToFavorites.Contains(client));
        }

        [Test]
        public void RemoveFromFavoritesThrowsArgumentNullExceptionOnClient()
        {
            var item = new TestItem();
            Assert.Throws<ArgumentNullException>(() => item.RemoveFromFavorites(null));
        }

        [Test]
        public void RemoveFromFavoritesRemovesClientFromFavorites()
        {
            var item = new TestItem();
            var client = new Client();
            item.AddToFavorites(client);
            item.RemoveFromFavorites(client);

            Assert.IsFalse(item.AddedToFavorites.Contains(client));
        }

        [Test]
        public void AddReviewThrowsArgumentNullExceptionOnReview()
        {
            var item = new TestItem();
            var client = new Client();
            Assert.Throws<ArgumentNullException>(() => item.AddReview(null, client));
        }

        [Test]
        public void AddReviewThrowsArgumentNullExceptionOnClient()
        {
            var item = new TestItem();
            var review = new Review();
            Assert.Throws<ArgumentNullException>(() => item.AddReview(review, null));
        }

        [Test]
        public void AddReviewAddsReview()
        {
            var item = new TestItem();
            var review = new Review();
            var client = new Client();
            item.AddReview(review, client);

            Assert.IsTrue(item.Reviews.Contains(review));
        }

        [Test]
        public void RemoveReviewThrowsArgumentNullExceptionOnReview()
        {
            var item = new TestItem();
            var client = new Client();
            Assert.Throws<ArgumentNullException>(() => item.RemoveReview(null, client));
        }

        [Test]
        public void RemoveReviewRemovesReview()
        {
            var item = new TestItem();
            var review = new Review();
            var client = new Client();
            item.AddReview(review, client);
            item.RemoveReview(review, client);

            Assert.IsFalse(item.Reviews.Contains(review));
        }
}