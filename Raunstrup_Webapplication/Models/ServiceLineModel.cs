using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class ServiceLineModel
    {
        [Required]
        [Display(Name = "Service Line ID")]
        public int Service_Line_ID { get; set; }

        [Display(Name = "Resource ID")]
        public ResourceModel Resource_ID { get; set; }

        [Display(Name = "Service ID")]
        public ServiceModel Service_ID { get; set; }

        [Display(Name = "Resource Quantity")]
        public int Resource_Quantity { get; set; }

        [Display(Name = "Offer ID")]
        public OfferModel Offer_ID { get; set; }
    }
}
