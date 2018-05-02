using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DbFirst;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    class DeerializeAndThenSerialize
    {
        [TestCase]
        public void DeserializeToSerializeRestaurant()
        {
            List<RestaurantInfo> restaurants = null;


            //Arrange
            //Deserialize
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
            //Serialize
            File.WriteAllText(@"C:\Users\Raptor\Downloads\reserializedRestaurantJson.json", JsonConvert.SerializeObject(restaurants,Formatting.Indented));


            //Act
            using (StreamReader originalFile = File.OpenText(@"C:\Users\Raptor\Downloads\restaurantJson.json"))
            using (StreamReader newFile = File.OpenText(@"C:\Users\Raptor\Downloads\reserializedRestaurantJson.json"))
            {
                //Assert
                Assert.AreEqual(originalFile.ToString(), newFile.ToString());
            }          
        }        
    }
}
