using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DbContextTest
    {
        private ProjectZeroDbContext context;
        [OneTimeSetUp]
        public void init()
        {
            context = new ProjectZeroDbContext();
        }
        
        [TestCase]
        public void testGetAllRestaurants()
        {
            //Arrange
            int expectedCount = 2; //assuming your db isnt empty
            //Act
            var results = context.RestaurantInfoes;

            //Assert
            Assert.Greater(results.Count(), expectedCount);
        }

        [TestCase]
        public void testGetAllReviews()
        {
            //Arrange
            int expectedCount = 2; //assuming your db isnt empty
            //Act
            var results = context.ReviewerInfoes;

            //Assert
            Assert.Greater(results.Count(), expectedCount);
        }

    }
}
