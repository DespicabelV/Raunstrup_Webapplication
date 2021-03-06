﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class EmployeeVehicleModel
    { 
        [Key][Required]
        [Display(Name = "License Plate")]
        public int License_Plate { get; set; }

        [Display(Name = "Kilometer Price")]
        public double Km_Price { get; set; }

        [Display(Name = "Day Price")]
        public double Day_Price { get; set; }

        public string Type { get; set; }

        [Display(Name = "Employee ID")]
        public EmployeeModel ForeignKey1_ { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
