using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.ViewModel
{
    //Nichlas
    public class OfferViewModel
    {
        public IEnumerable<OfferModel> OfferModels { get; set; }
        public OfferModel OfferModel { get; set; }
        public IEnumerable<CustomerModel> CustomerModels { get; set; }
        public CustomerModel CustomerModel { get; set; }
    }
}
