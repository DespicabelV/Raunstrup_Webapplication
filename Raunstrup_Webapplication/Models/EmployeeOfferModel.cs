using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class EmployeeOfferModel 
    {
        [Key]
        public int EmployeeOffer_ID { get; set; }

        public OfferModel ForeignKey1_ { get; set; }
        public EmployeeModel ForeignKey2_ { get; set; }
    }
}
