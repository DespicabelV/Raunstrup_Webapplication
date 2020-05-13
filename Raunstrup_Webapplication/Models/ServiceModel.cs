using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class ServiceModel
    {
        [Required] [Key]
        [Display(Name = "Service ID")]
        public int Service_ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
