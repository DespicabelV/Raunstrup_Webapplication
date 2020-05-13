using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;

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
            return View();
        }

        // POST: EmployeeOffer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeOffer_ID")] EmployeeOfferModel employeeOfferModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeOfferModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeOfferModel);
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
