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
    public class EmployeeVehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeVehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeVehicle
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeVehicleModel.ToListAsync());
        }

        // GET: EmployeeVehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeVehicleModel = await _context.EmployeeVehicleModel
                .FirstOrDefaultAsync(m => m.License_Plate == id);
            if (employeeVehicleModel == null)
            {
                return NotFound();
            }

            return View(employeeVehicleModel);
        }

        // GET: EmployeeVehicle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeVehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("License_Plate,Km_Price,Day_Price,Type")] EmployeeVehicleModel employeeVehicleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeVehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVehicleModel);
        }

        // GET: EmployeeVehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeVehicleModel = await _context.EmployeeVehicleModel.FindAsync(id);
            if (employeeVehicleModel == null)
            {
                return NotFound();
            }
            return View(employeeVehicleModel);
        }

        // POST: EmployeeVehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("License_Plate,Km_Price,Day_Price,Type")] EmployeeVehicleModel employeeVehicleModel)
        {
            if (id != employeeVehicleModel.License_Plate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeVehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeVehicleModelExists(employeeVehicleModel.License_Plate))
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
            return View(employeeVehicleModel);
        }

        // GET: EmployeeVehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeVehicleModel = await _context.EmployeeVehicleModel
                .FirstOrDefaultAsync(m => m.License_Plate == id);
            if (employeeVehicleModel == null)
            {
                return NotFound();
            }

            return View(employeeVehicleModel);
        }

        // POST: EmployeeVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeVehicleModel = await _context.EmployeeVehicleModel.FindAsync(id);
            _context.EmployeeVehicleModel.Remove(employeeVehicleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeVehicleModelExists(int id)
        {
            return _context.EmployeeVehicleModel.Any(e => e.License_Plate == id);
        }
    }
}
