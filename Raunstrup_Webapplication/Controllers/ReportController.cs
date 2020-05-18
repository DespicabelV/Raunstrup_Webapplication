using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;

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

        // GET: Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportModel = await _context.OfferModel
                .FirstOrDefaultAsync(m => m.Offer_ID == id);
            if (reportModel == null)
            {
                return NotFound();
            }

            return View(reportModel);
        }
    }
}