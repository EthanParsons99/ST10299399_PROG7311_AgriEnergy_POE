using Microsoft.AspNetCore.Mvc;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string FarmerPassword { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
