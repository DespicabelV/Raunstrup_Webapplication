using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.ViewModel
{
    public class AllanViewModel
    {


    }

    public class PrintViewModel
    {
        public IEnumerable<OfferModel> OfferModels { get; set; }
        public IEnumerable<CustomerModel> CustomerModels { get; set; }
        
    }
}
