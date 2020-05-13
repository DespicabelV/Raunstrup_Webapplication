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
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceModel.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel
                .FirstOrDefaultAsync(m => m.Service_ID == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Service_ID,Name")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel.FindAsync(id);
            if (serviceModel == null)
            {
                return NotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Service_ID,Name")] ServiceModel serviceModel)
        {
            if (id != serviceModel.Service_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.Service_ID))
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
            return View(serviceModel);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel
                .FirstOrDefaultAsync(m => m.Service_ID == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceModel = await _context.ServiceModel.FindAsync(id);
            _context.ServiceModel.Remove(serviceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
            return _context.ServiceModel.Any(e => e.Service_ID == id);
        }
    }
}
