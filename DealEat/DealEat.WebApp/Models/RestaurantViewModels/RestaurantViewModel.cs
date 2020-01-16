using System;

namespace DealEat.WebApp.Models
{
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Adresse { get; set; }

        public string  PhotoLink { get; set; }

        public int Telephone { get; set; }

        public string Category { get; set; }
    }
}