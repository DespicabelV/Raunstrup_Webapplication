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
            return View(await _context.ServiceLineModel.ToListAsync());
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
            return View();
        }

        // POST: ServiceLine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Service_Line_ID,Resource_Quantity")] ServiceLineModel serviceLineModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceLineModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceLineModel);
        }

        // GET: ServiceLine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceLineModel = await _context.ServiceLineModel.FindAsync(id);
            if (serviceLineModel == null)
            {
                return NotFound();
            }
            return View(serviceLineModel);
        }

        // POST: ServiceLine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Service_Line_ID,Resource_Quantity")] ServiceLineModel serviceLineModel)
        {
            if (id != serviceLineModel.Service_Line_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceLineModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceLineModelExists(serviceLineModel.Service_Line_ID))
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
            return View(serviceLineModel);
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
