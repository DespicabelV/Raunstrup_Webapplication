using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class ResourceModel
    {       
        [Required]
        [Display(Name = "Resource ID")]
        public int Res_ID { get; set; }

        public string Name { get; set; }

    }
}
