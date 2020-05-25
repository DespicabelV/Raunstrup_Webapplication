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
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Order
        public async Task<IActionResult> Index()
        {
            var order= _context.OrderModel.ToList();
            var offer = _context.OfferModel.ToList();
            var customer = _context.CustomerModel.ToList();

            var Viewmodel = new JacobViewModel
            {
                OrderModels = order,
                OfferModels = offer,
                CustomerModels = customer

            };

            return View(Viewmodel);
        }

        //GET: Order/Details/5
        public async Task<IActionResult> Details(int id, [Bind("Offer.Offer_ID")] JacobViewModel viewModel)
        {
            var orderModel = new OrderModel()
            {
                ForeignKey2_ = viewModel.Order.ForeignKey2_,
                ForeignKey1_ =viewModel.Order.ForeignKey1_,
                Price = viewModel.Order.Price
            };
            var Offerid = _context.OfferModel.Find(id);
            var CustomerID = _context.CustomerModel.Find(viewModel.Order.ForeignKey2_.Costumor_Id);

            orderModel.ForeignKey2_ = CustomerID;
            orderModel.ForeignKey1_ = Offerid;

            _context.OrderModel.Add(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //public async Task<IActionResult> Details(int? id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var offer = _context.OfferModel.ToList();
        //    var customer = _context.CustomerModel.ToList();
        //    var order = _context.OrderModel.Where(o => o.Order_ID== id).ToList();



        //    var Viewmodel = new JacobViewModel
        //    {
        //        OrderModels = order,
        //        OfferModels = offer,
        //        CustomerModels = customer


        //    };

        //    return View(Viewmodel);
        //}

        // GET: Order/Create
        public IActionResult Create()
        {
            var order = _context.OrderModel.ToList();
            var offer = _context.OfferModel.ToList();
            var customer = _context.CustomerModel.ToList();

            var Viewmodel = new JacobViewModel
            {
                OrderModels = order,
                OfferModels = offer,
                CustomerModels = customer

            };
            return View(Viewmodel);
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JacobViewModel viewModel)
        {
            var orderModel = new OrderModel
            {
                    ForeignKey2_ = viewModel.Order.ForeignKey2_,
                    ForeignKey1_ = viewModel.Order.ForeignKey1_,
                    Price = viewModel.Order.Price
            }; 
           var CustomerID = _context.CustomerModel.Find(viewModel.Order.ForeignKey2_.Costumor_Id);
           var OfferID = _context.OfferModel.Find(viewModel.Order.ForeignKey1_.Offer_ID);

           orderModel.ForeignKey2_ = CustomerID;
           orderModel.ForeignKey1_ = OfferID;
           
           _context.OrderModel.Add(orderModel); 
           await _context.SaveChangesAsync(); 
           return RedirectToAction(nameof(Index));
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }
            return View(orderModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order_ID,Price")] OrderModel orderModel)
        {
            if (id != orderModel.Order_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.OrderModel.FindAsync(id);
            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.Order_ID == id);
        }
    }
}
