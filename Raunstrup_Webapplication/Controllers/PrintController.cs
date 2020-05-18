using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.Controllers
{
    public class PrintController : Controller
    {
        public IActionResult Index()
        {
            var ressource = GetResource();
            return View(ressource);
        }

        private IEnumerable<ResourceModel> GetResource()
        {
            return new List<ResourceModel>()
            {
                new ResourceModel{Res_ID = 1, Customer_Price = 100, Name = "Tagsten", Store_Price = 20}
            };
        }
    }
}