using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.ViewModel
{
    public class EmployeeOfferViewModel
    {
        public IEnumerable<EmployeeOfferModel> EmployeeOfferModels { get; set; }
        public EmployeeOfferModel EmployeeOfferModel { get; set; }
        public IEnumerable<EmployeeModel> EmployeeModels { get; set; }
        public EmployeeModel EmployeeModel { get; set; }

        public IEnumerable<OfferModel> OfferModels { get; set; }
        public OfferModel OfferModel { get; set; }
    }
}
