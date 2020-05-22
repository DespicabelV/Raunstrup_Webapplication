using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.ViewModel
{
    public class JacobViewModel
    {
       public OfferModel Offer { get; set; }
       public IEnumerable<OfferModel> OfferModels { get; set; }
       public CustomerModel Customer { get; set; }
       public IEnumerable<CustomerModel> CustomerModels { get; set; }
       public OrderModel Order { get; set; }
       public IEnumerable<OrderModel> OrderModels { get; set; }
    }
}
