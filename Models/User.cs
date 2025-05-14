/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.AspNetCore.Mvc;

// User class representing a user in the system
// It contains properties for UserId, UserName, UserPassword, and Role
namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class User
    {
       public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Role { get; set; } // Farmer or Employee
    }
}
 //-----------================End of file=================--------------//