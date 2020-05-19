using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class ServiceLineModel
    {
        [Required] [Key]
        [Display(Name = "Service Line ID")]
        public int Service_Line_ID { get; set; }


        [Display(Name = "Resource ID")]
        public ResourceModel ForeignKey1_ { get; set; }

        [Display(Name = "Resource Quantity")]
        public int Resource_Quantity { get; set; }

        public int Used_Quantity { get; set; }

        public int Added_Quantity { get; set; }

        [Display(Name = "Service ID")]
        public ServiceModel ForeignKey2_ { get; set; }


        [Display(Name = "Offer ID")]
        public OfferModel ForeignKey3_ { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
