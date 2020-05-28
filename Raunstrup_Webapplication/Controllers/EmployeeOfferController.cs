using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.API;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;

namespace Raunstrup_Webapplication.Controllers
{
    public class EmployeeOfferController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeOfferController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Nnichlas
        // GET: EmployeeOffer/Create
        public IActionResult Create()
        {
            var employeeModels = _context.EmployeeModel.ToList();
            var offerModels = _context.OfferModel.ToList();
            var employeeOfferModels = _context.EmployeeOfferModel.ToList();
            var viewModel = new EmployeeOfferViewModel
            {
                EmployeeModels = employeeModels,
                OfferModels = offerModels,
                EmployeeOfferModels = employeeOfferModels
            };
            return View(viewModel);
        }


        //Nichlas
        // POST: EmployeeOffer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeOfferViewModel employeeOfferViewModel)
        {
            if (ModelState.IsValid)
            {
                var employeeOfferModel = new EmployeeOfferModel
                {
                    HoursWorked = employeeOfferViewModel.EmployeeOfferModel.HoursWorked,
                    ForeignKey1_ = employeeOfferViewModel.EmployeeOfferModel.ForeignKey1_,
                    ForeignKey2_ = employeeOfferViewModel.EmployeeOfferModel.ForeignKey2_,
                };
                var offerID =  _context.OfferModel.Find(employeeOfferViewModel.EmployeeOfferModel.ForeignKey1_.Offer_ID);
                var EmployeeID = _context.EmployeeModel.Find(employeeOfferViewModel.EmployeeOfferModel.ForeignKey2_.Employee_ID);
                employeeOfferModel.ForeignKey1_ = offerID;
                employeeOfferModel.ForeignKey2_ = EmployeeID;

                EmployeeOffer_APIController api = new EmployeeOffer_APIController(_context);
                await api.PostEmployeeOfferModel(employeeOfferModel);
            }
            return RedirectToAction("Create", "ServiceLine");
        }

        private bool EmployeeOfferModelExists(int id)
        {
            return _context.EmployeeOfferModel.Any(e => e.EmployeeOffer_ID == id);
        }
    }
}
