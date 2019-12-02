using System;
using System.Collections.Generic;
using System.Text;

namespace DealEat.DAL
{
    public class RestaurantData
    {
        // Data on View : dealeat.vRestaurant 
        
        // Restaurant
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string PhotoLink { get; set; }
        public int Telephone { get; set; }

    }
}
