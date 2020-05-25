using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.API;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;

namespace Raunstrup_Webapplication.Controllers
{
    public class ServiceLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceLine
        public async Task<IActionResult> Index()
        {
            var serviceLineModels = _context.ServiceLineModel.ToList();
            var serviceModel = _context.ServiceModel.ToList();
            var resourceModel = _context.ResourceModel.ToList();
            var offerModel = _context.OfferModel.ToList();
            var employeeOffersModels = _context.EmployeeOfferModel.ToList();

            var viewModel = new ServiceLineViewModel
            {
                ServiceLineModels = serviceLineModels,
                OfferModel = offerModel,
                ServiceModel = serviceModel,
                ResourceModel = resourceModel,
                EmployeeOfferModels = employeeOffersModels
            };

            return View(viewModel);
        }

        // GET: ServiceLine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceLineModel = await _context.ServiceLineModel
                .FirstOrDefaultAsync(m => m.Service_Line_ID == id);
            if (serviceLineModel == null)
            {
                return NotFound();
            }

            return View(serviceLineModel);
        }

        // GET: ServiceLine/Create
        public IActionResult Create()
        {
            var serviceLineModels = _context.ServiceLineModel.ToList();
            var serviceModel = _context.ServiceModel.ToList();
            var resourceModel = _context.ResourceModel.ToList();
            var offerModel = _context.OfferModel.ToList();
            var employeeOffersModels = _context.EmployeeOfferModel.ToList();
            var employeeModels = _context.EmployeeModel.ToList();
            

            var viewModel = new ServiceLineViewModel
            {
                ServiceLineModels = serviceLineModels,
                OfferModel = offerModel,
                ServiceModel = serviceModel,
                ResourceModel = resourceModel,
                EmployeeOfferModels = employeeOffersModels,
                EmployeeModels = employeeModels,
            };
            return View(viewModel);
        }

        // POST: ServiceLine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceLineViewModel serviceLineViewModel)
        {
            if (ModelState.IsValid)
            {
                var serviceLineModel = new ServiceLineModel
                {
                    ForeignKey2_ = serviceLineViewModel.ServiceLineModel.ForeignKey2_,
                    ForeignKey1_ = serviceLineViewModel.ServiceLineModel.ForeignKey1_,
                    ForeignKey3_ = serviceLineViewModel.ServiceLineModel.ForeignKey3_,
                    Added_Quantity = serviceLineViewModel.ServiceLineModel.Added_Quantity,
                    Used_Quantity = serviceLineViewModel.ServiceLineModel.Used_Quantity,
                    Resource_Quantity = serviceLineViewModel.ServiceLineModel.Resource_Quantity
                };

                var serviceID =
                    _context.ServiceModel.Find(serviceLineViewModel.ServiceLineModel.ForeignKey2_.Service_ID);
                var resID = _context.ResourceModel.Find(serviceLineViewModel.ServiceLineModel.ForeignKey1_.Res_ID);
                var offerID = _context.OfferModel.Find(serviceLineViewModel.ServiceLineModel.ForeignKey3_.Offer_ID);
                serviceLineModel.ForeignKey2_ = serviceID;
                serviceLineModel.ForeignKey1_ = resID;
                serviceLineModel.ForeignKey3_ = offerID;

                ServiceLine_APIController api = new ServiceLine_APIController(_context);
                await api.PostEmployeeOfferModel(serviceLineModel);
                return RedirectToAction("Create");
            }

            return RedirectToAction("Create");
        }


        // GET: ServiceLine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceLineModel = await _context.ServiceLineModel
                .FirstOrDefaultAsync(m => m.Service_Line_ID == id);
            if (serviceLineModel == null)
            {
                return NotFound();
            }

            return View(serviceLineModel);
        }

        // POST: ServiceLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceLineModel = await _context.ServiceLineModel.FindAsync(id);
            _context.ServiceLineModel.Remove(serviceLineModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceLineModelExists(int id)
        {
            return _context.ServiceLineModel.Any(e => e.Service_Line_ID == id);
        }
    }
}
