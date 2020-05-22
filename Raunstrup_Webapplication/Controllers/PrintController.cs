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

        //public PrintController(IWebHostEnvironment _hostEnvironment)
        //{
        //    this._hostEnvironment = _hostEnvironment;
        //}



        // GET: Print/Index/OfferID
        public async Task<IActionResult> Index(string OfferID)
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

        public IActionResult PrintOffer(string OfferID)
        {
            List<OfferModel> offerModels = new List<OfferModel>();
            IEnumerable<OfferModel> _offerModel = _context.OfferModel.ToList().Where(x => Convert.ToString(x.Offer_ID).Contains(OfferID)).ToList();

            foreach (var i in _offerModel)
            {
                OfferModel offerModel = new OfferModel();
                offerModel.Offer_ID = Convert.ToInt32(i);
                offerModel.Offer_Title = "Title: " + i;
                offerModel.ForeignKey1_.Name = "Customer Name" + i;
                offerModel.Start_date = Convert.ToDateTime(i);
                offerModel.End_Date = Convert.ToDateTime(i);
                offerModel.Offer_Price = Convert.ToDouble(i);
                offerModels.Add(offerModel);
            }
            OfferPrint rtp = new OfferPrint(_hostEnvironment);
            return File(rtp.Print(offerModels), "application/pdf");


        }
    }
}