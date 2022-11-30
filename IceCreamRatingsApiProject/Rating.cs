using System;

namespace IceCreamRatingsApiProject
{
    public class RatingModel
    {
        public string userId { get; set; }
        public string productId { get; set; }
        public string locationName { get; set; }
        public int rating { get; set; }
        public string userNotes { get; set; }
    }


    public class Rating 
    {
        public string id { get; } = Guid.NewGuid().ToString();
        public string userId { get; set; }
        public string productId { get; set; }
        public string locationName { get; set; }
        public int rating { get; set; }
        public string userNotes { get; set;  }
    }
}
