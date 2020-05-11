using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class CustomerModel
    {
        [Required] [Key]
        [Display(Name = "Costumer ID")]
        public int Costumor_Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Address  { get; set; }

        [EmailAddress]
        [Display(Name = "Mail Address")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public int Phone_Num { get; set; }

        [Range(1,3)]
        [Display(Name = "Customer Group")]
        public byte Custumor_Group { get; set; }
    }
}