using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Raunstrup_Webapplication.API;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

//Lavet af Allan
namespace Raunstrup_Webapplication.Controllers
{
    public class PrintController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostEnvironment;

        public PrintController(ApplicationDbContext _context, IWebHostEnvironment _hostEnvironment)
        {
            this._context = _context;
            this._hostEnvironment = _hostEnvironment;
        }

        // GET: Print/Index/OfferID
        public IActionResult Index(string OfferID)
        {
            var offerViewModel = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();
            var customerViewModel = _context.CustomerModel.ToList();
            var viewModel = new PrintViewModel
            {
                OfferModels = offerViewModel,
                CustomerModels = customerViewModel
            };

            if (OfferID != null)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult PrintOffer(string OfferID)
        {
            var customerViewModel = _context.CustomerModel.ToList();
            var offerViewModel = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();

            var viewModel = new PrintViewModel()
            {
                OfferModels = offerViewModel,
                CustomerModels = customerViewModel
            };

            List<OfferModel> Offer = new List<OfferModel>();
            List<OfferModel> OfferDetails = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();

            foreach (var i in OfferDetails)
            {
                OfferModel offerModel = new OfferModel();
                offerModel.End_Date = i.End_Date;
                offerModel.ForeignKey1_ = i.ForeignKey1_;
                offerModel.Offer_ID = i.Offer_ID;
                offerModel.Offer_Price = i.Offer_Price;
                offerModel.Offer_Title = i.Offer_Title;
                offerModel.Start_date = i.Start_date;

                Offer.Add(offerModel);
            }

            Print_APIController Print_Api = new Print_APIController(_hostEnvironment);
            return File(Print_Api.Print(Offer), "application/pdf");
        }
    }
}