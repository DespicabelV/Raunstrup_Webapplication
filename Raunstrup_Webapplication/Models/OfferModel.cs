﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class OfferModel
    {
        [Required] [Key]
        [Display(Name = "Offer ID")]
        public int Offer_ID { get; set; }

        [Display(Name = "Offer Title")]
        public string Offer_Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime Start_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }

        [Display(Name = "Offer Price")]
        [DisplayFormat(DataFormatString = "{0:C1}")]
        public double Offer_Price { get; set; }

        [Display(Name = "Customer ID")]
        public CustomerModel ForeignKey1_ { get; set; }

        public string Status { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
