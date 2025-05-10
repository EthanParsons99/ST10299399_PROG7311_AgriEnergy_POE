using Microsoft.AspNetCore.Mvc;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class Product
    {
       public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public DateTime ProductDate { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
