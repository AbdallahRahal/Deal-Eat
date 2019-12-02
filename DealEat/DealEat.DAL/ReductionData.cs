using System;
using System.Collections.Generic;
using System.Text;

namespace DealEat.DAL
{
    public class ReductionData
    {
        public int BracketId { get; set; }

        public string Name { get; set; }

        public string PhotoLink { get; set; }

        public int Price { get; set; }

        public string Information { get; set; }

        public int RestaurantId { get; set; }

        public int SoldId { get; set; }

        public int Reduction { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndState { get; set; }

        public int BracketIdE { get; set; }
    }
}


// *BracketId Name Photolink price Information *RestaurantId
// SoldId Reduction Start_Date En_Date *BracketId