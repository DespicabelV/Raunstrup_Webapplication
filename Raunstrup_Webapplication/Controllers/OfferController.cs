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
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfferController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Nichlas
        // GET: Offer
        public IActionResult Index(string OfferID)
        {

            if (OfferID == null)
            {
                var customerViewModel = _context.CustomerModel.ToList();
                var offerViewModels = _context.OfferModel.ToList();
                var viewModel = new OfferViewModel()
                {
                    OfferModels = offerViewModels
                };
                return View(viewModel);
            }
            var customerViewModelWithID = _context.CustomerModel.ToList();
            var offerViewModelsWithID = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();
            var viewModelWithID = new OfferViewModel()
            {
                OfferModels = offerViewModelsWithID,
                CustomerModels = customerViewModelWithID
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

        //Nichlas
        // GET: Offer/Create
        public IActionResult Create()
        {
            var offerModel = _context.OfferModel.ToList();
            var customerModel = _context.CustomerModel.ToList();

            var viewModel = new OfferViewModel
            {
                OfferModels = offerModel,
                CustomerModels = customerModel
            };

            return View(viewModel);
        }


        //Nichlas
        // POST: Offer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfferViewModel offerViewModel)
        {
            
            var offerModel = new OfferModel
            {
                Offer_ID = offerViewModel.OfferModel.Offer_ID,
                Offer_Title = offerViewModel.OfferModel.Offer_Title,
                Offer_Price = offerViewModel.OfferModel.Offer_Price,
                Start_date = offerViewModel.OfferModel.Start_date,
                End_Date = offerViewModel.OfferModel.End_Date,
                Status = offerViewModel.OfferModel.Status,
                ForeignKey1_ = offerViewModel.OfferModel.ForeignKey1_
            };
            var customerID = _context.CustomerModel.Find(offerViewModel.OfferModel.ForeignKey1_.Costumor_Id);
            offerModel.ForeignKey1_ = customerID;

            Offer_APIController api = new Offer_APIController(_context);
            await api.PostOfferModel(offerModel);

            return RedirectToAction("Create", "ServiceLine");

        }
        private bool OfferModelExists(int id)
        {
            return _context.OfferModel.Any(e => e.Offer_ID == id);
        }
    }
}
