using Raunstrup_Webapplication.Models;
using System.Collections.Generic;

namespace Raunstrup_Webapplication.ViewModel
{
    public class OrderViewModel
    {
        public OfferModel Offer { get; set; }
        public IEnumerable<OfferModel> OfferModels { get; set; }
        public CustomerModel Customer { get; set; }
        public IEnumerable<CustomerModel> CustomerModels { get; set; }
        public OrderModel Order { get; set; }
        public IEnumerable<OrderModel> OrderModels { get; set; }
    }
}