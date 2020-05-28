using Microsoft.AspNetCore.Mvc;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using Raunstrup_Webapplication.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup_Webapplication.Controllers //Jacob
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
            var order = _context.OrderModel.ToList();
            var offer = _context.OfferModel.ToList();
            var customer = _context.CustomerModel.ToList();

            var Viewmodel = new OrderViewModel
            {
                OrderModels = order,
                OfferModels = offer,
                CustomerModels = customer
            };

            return View(Viewmodel);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            var order = _context.OrderModel.ToList();
            var offer = _context.OfferModel.ToList();
            var customer = _context.CustomerModel.ToList();

            var Viewmodel = new OrderViewModel
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
        public async Task<IActionResult> Create(OrderViewModel viewModel)
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

        

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.Order_ID == id);
        }
    }
}