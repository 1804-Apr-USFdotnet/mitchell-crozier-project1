using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;

namespace Test
{
    [TestFixture]
    class DeserializeTest
    {
        [TestCase]
        public void TestDeserializeSingleRestaurantFromFile()
        {
            RestaurantInfo restaurant = null;

            //Arrange
            try
            {
                using (StreamReader file = File.OpenText(@"C:\Users\Raptor\Downloads\singleRestaurantJson.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    restaurant = (RestaurantInfo)serializer.Deserialize(file, typeof(RestaurantInfo));
                }
            } catch(FileNotFoundException e)
            {
                Assert.Fail("File not found");
            } catch (Exception e)
            {
                Assert.Fail("Cannot deserialize into the object type");
            }
            //Act
            int actual = restaurant.restaurantId;
            int expected = 1;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void TestDeserializeMultipleRestaurantsFromFile()
        {
            List<RestaurantInfo> restaurants = null;

            //Arrange
            try
            {
                using (StreamReader file = File.OpenText(@"C:\Users\Raptor\Downloads\restaurantJson.json"))
                {
                    restaurants = JsonConvert.DeserializeObject<List<RestaurantInfo>>(File.ReadAllText(@"C:\Users\Raptor\Downloads\restaurantJson.json"));
                }
            }
            catch (FileNotFoundException e)
            {
                Assert.Fail("File not found");
            }
            catch (Exception e)
            {
                Assert.Fail("Cannot deserialize into the object type");
            }
            //Act
            int actualCount = restaurants.Count;
            int expectedCount = 2;

            //Assert
            Assert.Greater(actualCount, expectedCount);
        }

        

        [TestCase]
        public void TestDeserializeMultipleReviewsFromFile()
        {
            List<ReviewerInfo> reviews = null;

            //Arrange
            try
            {
                using (StreamReader file = File.OpenText(@"C:\Users\Raptor\Downloads\reviewerJson.json"))
                {
                    reviews = JsonConvert.DeserializeObject<List<ReviewerInfo>>(File.ReadAllText(@"C:\Users\Raptor\Downloads\restaurantJson.json"));
                }
            }
            catch (FileNotFoundException e)
            {
                Assert.Fail("File not found");
            }
            catch (Exception e)
            {
                Assert.Fail("Cannot deserialize into the object type");
            }
            //Act
            int actualCount = reviews.Count;
            int expectedCount = 2;

            //Assert
            Assert.Greater(actualCount, expectedCount);
        }

    }
}
