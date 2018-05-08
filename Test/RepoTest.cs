using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using RepositoryInterfaces;
using Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Test
{
    
    class RepoTest
    {
        [Test]
        public void TestRepoDependencyInjection()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            restRepo.Setup(i => i.GetRestaurantById(34)).Returns(new RestaurantInfo(34,"repoTest", "test city", "test street", "descrip", "testemail"));
            var sut = new RestaurantService(restRepo.Object, reviewRepo.Object);
            var expected = new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail");
            var actual = sut.GetRestaurantById(34);
            Assert.AreEqual(expected, actual, "Nope");
        }

        [Test]
        public void TestConvertNameIntoId()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            List<int> restList = new List<int>();
            RestaurantInfo dummyRest = new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail");
            restList.Add(dummyRest.restaurantId);
            restRepo.Setup(i => i.ConvertNameIntoId("repoTest")).Returns(new List<int> {34});
            var service = new RestaurantService(restRepo.Object, reviewRepo.Object);
            var expected = restList;
            var actual = service.ConvertNameIntoId("repoTest");
            
            Assert.AreEqual(expected,actual, "Nope");
        }

        [Test]
        public void TestRestDelete()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new RestaurantService(restRepo.Object, reviewRepo.Object);

            restRepo.Setup(i => i.DeleteRestaurantById(34)).Returns(true);
            var expected = true;
            var actual = service.DeleteRestaurantById(34);
            Assert.AreEqual(expected,actual, "Delete failed");
        }

        [Test]
        public void TestRestUpdate()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new RestaurantService(restRepo.Object, reviewRepo.Object);
            RestaurantInfo dummyRest = new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail");

            restRepo.Setup(i => i.UpdateRestaurant(new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail"))).Returns(true);
            var expected = true;
            var actual = service.UpdateRestaurant(dummyRest);
            Assert.AreEqual(expected, actual, "Delete failed");
        }

        [Test]
        public void TestRestAdd()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new RestaurantService(restRepo.Object, reviewRepo.Object);
            RestaurantInfo dummyRest = new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail");

            restRepo.Setup(i => i.AddRestaurant(new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail"))).Returns(true);
            var expected = true;
            var actual = service.AddRestaurant(dummyRest);
            Assert.AreEqual(expected, actual, "Delete failed");
        }

        [Test]
        public void TestRestRead()
        {
            var restRepo = new Mock<IRestaurantRepository>();
            var reviewRepo = new Mock<IReviewerRepository>();
            var service = new RestaurantService(restRepo.Object, reviewRepo.Object);
            RestaurantInfo dummyRest = new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail");

            restRepo.Setup(i => i.GetRestaurantById(34)).Returns(new RestaurantInfo(34, "repoTest", "test city", "test street", "descrip", "testemail"));
            var expected = dummyRest;
            
            var actual = service.GetRestaurantById(34);
            Assert.AreEqual(expected, actual, "Delete failed");
        }

        


    }
}
