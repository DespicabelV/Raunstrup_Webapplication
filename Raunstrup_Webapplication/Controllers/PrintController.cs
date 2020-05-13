using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Raunstrup_Webapplication.Controllers
{
    public class PrintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}