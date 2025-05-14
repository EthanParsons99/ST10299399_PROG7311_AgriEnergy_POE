/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeEmail { get; set; }

    }
}
 //-----------================End of file=================--------------//