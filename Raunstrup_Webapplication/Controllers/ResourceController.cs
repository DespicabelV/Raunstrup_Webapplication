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
    public class ResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resource
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResourceModel.ToListAsync());
        }

        // GET: Resource/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceModel = await _context.ResourceModel
                .FirstOrDefaultAsync(m => m.Res_ID == id);
            if (resourceModel == null)
            {
                return NotFound();
            }

            return View(resourceModel);
        }

        // GET: Resource/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Res_ID,Name")] ResourceModel resourceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resourceModel);
        }

        // GET: Resource/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceModel = await _context.ResourceModel
                .FirstOrDefaultAsync(m => m.Res_ID == id);
            if (resourceModel == null)
            {
                return NotFound();
            }

            return View(resourceModel);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceModel = await _context.ResourceModel.FindAsync(id);
            _context.ResourceModel.Remove(resourceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceModelExists(int id)
        {
            return _context.ResourceModel.Any(e => e.Res_ID == id);
        }
    }
}
