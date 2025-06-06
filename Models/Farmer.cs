﻿/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Text.Json.Serialization;

// Farmer class representing a farmer in the system
// It contains properties for FarmerId, FarmerName, FarmerSurname, FarmerPhone, FarmerEmail, and FarmerPassword
namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string FarmerSurname { get; set; }
        public string FarmerPhone { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerPassword { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
 //-----------================End of file=================--------------//