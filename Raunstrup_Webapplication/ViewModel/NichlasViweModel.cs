using System;
using System.Collections.Generic;
using System.Linq;
using Raunstrup_Webapplication.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Raunstrup_Webapplication.ViewModel
{
    public class NichlasViweModel
    {

    }

    public class ServiceLineViewModel
    {
        public IEnumerable<ServiceLineModel>  ServiceLineModels { get; set; }

        public ServiceLineModel ServiceLineModel { get; set; }

        public IEnumerable<OfferModel> OfferModel { get; set; }

        public List<ServiceModel> ServiceModel { get; set; }

        public List<ResourceModel> ResourceModel { get; set; }

        public IEnumerable<EmployeeOfferModel> EmployeeOfferModels { get; set; }

        public EmployeeOfferModel EmployeeOfferModel { get; set; }

        public IEnumerable<EmployeeModel> EmployeeModels { get; set; }
    }

    public class OfferViewModel
    {
        public IEnumerable<OfferModel> OfferModels { get; set; }
        public OfferModel OfferModel { get; set; }

    }
}
