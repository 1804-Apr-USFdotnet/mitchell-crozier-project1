using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class RestaurantViewModel
    {
        public int restaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}