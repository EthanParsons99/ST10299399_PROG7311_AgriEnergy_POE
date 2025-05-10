using Microsoft.AspNetCore.Mvc;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class User
    {
       public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Role { get; set; } // "Farmer" or "Employee"
    }
}
