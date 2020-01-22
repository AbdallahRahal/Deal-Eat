using System;

namespace DealEat.WebApp.Models
{
    public class FeedbackViewModel
    {
        public int FeedbackId { get; set; }

        public int Note { get; set; }

        public string Feedback { get; set; }

        public int CustomerId { get; set; }

        public int RestaurantId { get; set; }
    }
}