using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Raunstrup_Webapplication.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Details(int? id)
        {
            var serviceModel = _context.ServiceModel.ToList();
            var offerModel = _context.OfferModel.ToList();
            var resourceModel = _context.ResourceModel.ToList();
            var employeeModel = _context.EmployeeModel.ToList();
            var employeeOfferModel = _context.EmployeeOfferModel.ToList();
            var customerModel = _context.CustomerModel.ToList();

            var serviceLineModels = _context.ServiceLineModel.Where(a => a.ForeignKey3_.Offer_ID == id).ToList();
            var employeeOfferModels = _context.EmployeeOfferModel.Where(a => a.ForeignKey1_.Offer_ID == id).ToList();
            var offermodels = _context.OfferModel.Where(a => a.Offer_ID == id).ToList();

            var resourceModels = new List<ResourceModel>();
            var employeeModels = new List<EmployeeModel>();

            foreach (var item in serviceLineModels)
            {
                resourceModels.Add(_context.ResourceModel.FirstOrDefault(m => m.Res_ID == item.ForeignKey1_.Res_ID));
            }

            foreach (var item in employeeOfferModels)
            {
                employeeModels.Add(_context.EmployeeModel.FirstOrDefault(m => m.Employee_ID == item.ForeignKey2_.Employee_ID));
            }

            var viewModel = new ViggoViweModel
            {
                ServiceLineModels = serviceLineModels,
                ResourceModels = resourceModels,
                EmployeeOfferModels = employeeOfferModels,
                EmployeeModels = employeeModels,
                Offermodels = offermodels
            };


            return View(viewModel);
        }
    }
}