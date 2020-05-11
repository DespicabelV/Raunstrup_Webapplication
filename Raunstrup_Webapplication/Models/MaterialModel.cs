using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class MaterialModel : ResourceModel
    {
        [Display(Name = "Store Price")]
        public double Store_Price { get; set; }

        [Display(Name = "Customer Price")]
        public double Customer_Price { get; set; }
    }
}
