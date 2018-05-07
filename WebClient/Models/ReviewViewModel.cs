using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class ReviewViewModel
    {
        public int reviewerId { get; set; }
        public int restaurantId { get; set; }
        public string ReviewerName { get; set; }
        [Range(1,10, ErrorMessage = "Try again yo has to be within 1-10")]
        public int Rating { get; set; }
        public System.DateTime Date { get; set; }
    }
}