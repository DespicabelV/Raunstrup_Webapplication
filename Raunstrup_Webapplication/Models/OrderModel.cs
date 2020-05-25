using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class OrderModel
    {
        [Required] [Key]
        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }
        [Display(Name = "Offer ID")]
        public OfferModel ForeignKey1_ { get; set; }

        [DisplayFormat(DataFormatString = "{0:C1}")]
        public double Price { get; set; }

        [Display(Name = "Customer ID")]
        public CustomerModel ForeignKey2_ { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
