using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Raunstrup_Webapplication.Models
{
    public class ResourceModel
    {       
        [Required] [Key]
        [Display(Name = "Resource ID")]
        public int Res_ID { get; set; }


        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C1}")]
        [Display(Name = "Store Price")]
        public double Store_Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:C1}")]
        [Display(Name = "Customer Price")]
        public double Customer_Price { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
