using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.API;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Details(int? id)
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

            var viewModel = new ReportViewModel()
            {
                ServiceLineModels = serviceLineModels,
                ResourceModels = resourceModels,
                EmployeeOfferModels = employeeOfferModels,
                EmployeeModels = employeeModels,
                Offermodels = offermodels
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ReportDetails(int[] resArray, int[] hoursArray)
        {
            ServiceLine_APIController ServiceLine_API = new ServiceLine_APIController(_context);
            EmployeeOffer_APIController employeeOffer_Api = new EmployeeOffer_APIController(_context);

            for (int i = 0; i < resArray.Length; i = i + 2)
            {
                var data = await _context.ServiceLineModel.FirstOrDefaultAsync(m => m.Service_Line_ID == resArray[i]);
                data.Used_Quantity = data.Used_Quantity + resArray[i + 1];
                await ServiceLine_API.PutServiceLineModel(resArray[i], data);
            }

            for (int i = 0; i < hoursArray.Length; i = i + 2)
            {
                var data = await _context.EmployeeOfferModel.FirstOrDefaultAsync(m => m.EmployeeOffer_ID == hoursArray[i]);
                data.HoursWorked = data.HoursWorked + hoursArray[i + 1];
                await employeeOffer_Api.PutEmployeeOfferModel(hoursArray[i], data);
            }

            return Accepted();
        }
    }
}