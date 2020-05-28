using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.ViewModel
{
    //Viggo
    public class ReportViewModel
    {
        public ServiceLineModel ServiceLineModel { get; set; }
        public ResourceModel ResourceModel { get; set; }
        public EmployeeModel EmployeeModel { get; set; }
        public EmployeeOfferModel EmployeeOfferModel { get; set; }
        public OfferModel OfferModel { get; set; }
        public List<ServiceLineModel> ServiceLineModels { get; set; }
        public List<ResourceModel> ResourceModels { get; set; }
        public List<EmployeeModel> EmployeeModels { get; set; }
        public List<EmployeeOfferModel> EmployeeOfferModels { get; set; }
        public List<OfferModel> Offermodels { get; set; }
    }
}
