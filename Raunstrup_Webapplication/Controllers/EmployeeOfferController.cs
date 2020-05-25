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

        // GET: EmployeeOffer
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeOfferModel.ToListAsync());
        }

        // GET: EmployeeOffer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeOfferModel = await _context.EmployeeOfferModel
                .FirstOrDefaultAsync(m => m.EmployeeOffer_ID == id);
            if (employeeOfferModel == null)
            {
                return NotFound();
            }

            return View(employeeOfferModel);
        }

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

                Nichlas_Temp_API api = new Nichlas_Temp_API(_context);
                await api.PostEmployeeOfferModel(employeeOfferModel);
            }
            return RedirectToAction("Create", "ServiceLine");
        }

        // GET: EmployeeOffer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeOfferModel = await _context.EmployeeOfferModel.FindAsync(id);
            if (employeeOfferModel == null)
            {
                return NotFound();
            }
            return View(employeeOfferModel);
        }

        // POST: EmployeeOffer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeOffer_ID")] EmployeeOfferModel employeeOfferModel)
        {
            if (id != employeeOfferModel.EmployeeOffer_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeOfferModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeOfferModelExists(employeeOfferModel.EmployeeOffer_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeOfferModel);
        }

        // GET: EmployeeOffer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeOfferModel = await _context.EmployeeOfferModel
                .FirstOrDefaultAsync(m => m.EmployeeOffer_ID == id);
            if (employeeOfferModel == null)
            {
                return NotFound();
            }

            return View(employeeOfferModel);
        }

        // POST: EmployeeOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeOfferModel = await _context.EmployeeOfferModel.FindAsync(id);
            _context.EmployeeOfferModel.Remove(employeeOfferModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeOfferModelExists(int id)
        {
            return _context.EmployeeOfferModel.Any(e => e.EmployeeOffer_ID == id);
        }
    }
}
