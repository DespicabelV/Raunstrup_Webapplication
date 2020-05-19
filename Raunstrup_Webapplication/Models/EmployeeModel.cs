using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Models
{
    public class EmployeeModel
    {
        [Required] [Key]
        [Display(Name = "Employee ID")]
        public int Employee_ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double Salary { get; set; }

        public string Expertise { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
