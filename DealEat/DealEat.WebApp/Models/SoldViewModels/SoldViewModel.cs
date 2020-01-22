using System;

namespace DealEat.WebApp.Models
{
    public class SoldViewModel
    {
        public int SoldId { get; set; }
        public int Reduction { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int BracketId { get; set; }

    }
}