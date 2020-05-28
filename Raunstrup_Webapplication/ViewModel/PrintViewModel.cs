using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

//Lavet af Allan
namespace Raunstrup_Webapplication.ViewModel
{
    public class PrintViewModel
    {
        public IEnumerable<OfferModel> OfferModels { get; set; }
        public IEnumerable<CustomerModel> CustomerModels { get; set; }
        public OfferModel OfferModel { get; set; }
        public CustomerModel CustomerModel { get; set; }
    }
}
