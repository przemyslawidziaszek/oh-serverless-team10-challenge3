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
        public Rating(RatingModel obj)
        { 
            userId = obj.userId;
            productId = obj.productId;
            locationName = obj.locationName;
            rating = obj.rating;
            userNotes = obj.userNotes;
        }

        public string ratingId { get; } = Guid.NewGuid().ToString();
        public string userId { get; }
        public string productId { get;  }
        public string locationName { get; }
        public int rating { get; }
        public string userNotes { get; }
    }
}
