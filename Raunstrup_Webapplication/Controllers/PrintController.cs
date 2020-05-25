using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.API;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;


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
            List<OfferModel> Offer = new List<OfferModel>();
            var offerViewModel = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();
            List<OfferModel> OfferDetails = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(OfferID)).ToList();

            var array = new object[5];

            var customerViewModel = _context.CustomerModel.ToList();

            var viewModel = new PrintViewModel()
            {
                OfferModels = offerViewModel,
                CustomerModels = customerViewModel
            };


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



            
            Print_APIController rtp = new Print_APIController(_hostEnvironment);
            return File(rtp.Print(Offer), "application/pdf");


        }
    }
}