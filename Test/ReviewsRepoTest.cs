using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst;
using Moq;
using NUnit.Framework;
using RepositoryInterfaces;
using Services;


namespace Test
{
    class ReviewsRepoTest
    {
        [Test]
        public void TestReviewDelete()
        {
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new ReviewerService(reviewRepo.Object);

            reviewRepo.Setup(i => i.DeleteReviewById(34)).Returns(true);
            var expected = true;
            var actual = service.DeleteReviewById(34);
            Assert.AreEqual(expected, actual, "Delete failed");
        }

        [Test]
        public void TestReviewUpdate()
        {
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new ReviewerService(reviewRepo.Object);
            var dummyReview = new ReviewerInfo(34,22,"Oh hi mark", 7, DateTime.Today);
            reviewRepo.Setup(i => i.UpdateReview(new ReviewerInfo(34,22,"Oh hi mark", 7, DateTime.Today))).Returns(true);
            var expected = true;
            var actual = service.UpdateReview(dummyReview);
            Assert.AreEqual(expected, actual, "Update failed");
        }

        [Test]
        public void TestReviewAdd()
        {
            
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new ReviewerService(reviewRepo.Object);
            var dummyReview = new ReviewerInfo(34, 22, "Oh hi mark", 7, DateTime.Today);
            reviewRepo.Setup(i => i.AddReview( new ReviewerInfo(34, 22, "Oh hi mark", 7, DateTime.Today))).Returns(true);
            var expected = true;
            var actual = service.AddReview(dummyReview);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual, "Delete failed");
        }

        [Test]
        public void TestReviewRead()
        {
            
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new ReviewerService(reviewRepo.Object);
            var dummyReview = new ReviewerInfo(34, 22, "Oh hi mark", 7, DateTime.Today);
            reviewRepo.Setup(i => i.GetReviewById(34)).Returns(new ReviewerInfo(34, 22, "Oh hi mark", 7, DateTime.Today));
            var expected = dummyReview;

            var actual = service.GetReviewById(34);
            Assert.AreEqual(expected, actual, "Delete failed");
        }
    }
}
