using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class OrderModel
    {
        [Required]
        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }

        [Display(Name = "Offer ID")]
        public OfferModel Offer_ID { get; set; }

        public double Price { get; set; }

        [Display(Name = "Customer ID")]
        public CustomerModel Customer_ID { get; set; }
    }
}
