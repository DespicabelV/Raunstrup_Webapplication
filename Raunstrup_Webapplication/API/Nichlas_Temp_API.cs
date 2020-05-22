using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nichlas_Temp_API : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Nichlas_Temp_API(ApplicationDbContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("Search")]
        public IActionResult Search()
        {
            try
            {
                string Filter = HttpContext.Request.Query["Filter"].ToString();
                var Titel = _context.OfferModel.Where(o => o.Offer_Title.Contains(Filter))
                    .Select(o => o.Offer_Title).ToList();
                return Ok(Titel);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

public class BusinessLogicController
{
    private readonly ApplicationDbContext _context;

}
