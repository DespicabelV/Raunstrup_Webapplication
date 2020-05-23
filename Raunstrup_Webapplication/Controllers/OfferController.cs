using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;

namespace Raunstrup_Webapplication.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfferController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offer
        public IActionResult Index(string OfferID)
        {
            //Søge Funktion til Navne uden viewmodels
            //if (OfferName != null)
            //{
            //    var Data = _context.OfferModel.Where(o => o.Offer_Title.Contains(OfferName)).ToList();
            //    return View(Data);
            //}
            //else
            //{
            //    return View(_context.OfferModel.ToList());
            //}


            if (OfferID == null)
            {
                var offerViewModels = _context.OfferModel.ToList();
                var viewModel = new OfferViewModel()
                {
                    OfferModels = offerViewModels
                };
                return View(viewModel);
            }
            var offerViewModelsWithID = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();
            var viewModelWithID = new OfferViewModel()
            {
                OfferModels = offerViewModelsWithID
            };
            return View(viewModelWithID);
        }

        // GET: Offer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.OfferModel
                .FirstOrDefaultAsync(m => m.Offer_ID == id);
            if (offerModel == null)
            {
                return NotFound();
            }

            return View(offerModel);
        }

        // GET: Offer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Offer_ID,Offer_Title,ForeignKey1_,Start_date,End_Date,Offer_Price,Status")] OfferModel offerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerModel);
        }

        // GET: Offer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.OfferModel.FindAsync(id);
            if (offerModel == null)
            {
                return NotFound();
            }
            return View(offerModel);
        }

        // POST: Offer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Offer_ID,Offer_Title,ForeignKey1_,Start_date,End_Date,Offer_Price,Status")] OfferModel offerModel)
        {
            if (id != offerModel.Offer_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferModelExists(offerModel.Offer_ID))
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
            return View(offerModel);
        }

        // GET: Offer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.OfferModel
                .FirstOrDefaultAsync(m => m.Offer_ID == id);
            if (offerModel == null)
            {
                return NotFound();
            }

            return View(offerModel);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerModel = await _context.OfferModel.FindAsync(id);
            _context.OfferModel.Remove(offerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferModelExists(int id)
        {
            return _context.OfferModel.Any(e => e.Offer_ID == id);
        }
    }
}
