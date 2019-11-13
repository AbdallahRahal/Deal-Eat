using System;
using System.Collections.Generic;
using System.Text;

namespace DealEat.DAL
{
    public class ReducData
    {
        public int RestaurantId { get; set; }
        public enum Type { merchant, admin, user }

        //public string Email { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Pseudo { get; set; }

        public byte[] Password { get; set; }
    }
}
