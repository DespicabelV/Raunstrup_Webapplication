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

        //SEARCH API for Int variables

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

        //EmployeOfferModel API's

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeOfferModel>> GetEmployeeOfferModel(int id)
        {
            var employeeOfferModel = await _context.EmployeeOfferModel.FindAsync(id);

            if (employeeOfferModel == null)
            {
                return NotFound();
            }

            return employeeOfferModel;
        }


        [HttpPost]
        public async Task<ActionResult<EmployeeOfferModel>> PostEmployeeOfferModel(EmployeeOfferModel employeeOfferModel)
        {
            _context.EmployeeOfferModel.Add(employeeOfferModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeOfferModel", new { id = employeeOfferModel.EmployeeOffer_ID }, employeeOfferModel);
        }



        //OfferModel API's

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferModel>> GetOfferModel(int id)
        {
            var OfferModel = await _context.OfferModel.FindAsync(id);

            if (OfferModel == null)
            {
                return NotFound();
            }

            return OfferModel;
        }


        [HttpPost]
        public async Task<ActionResult<OfferModel>> PostOfferModel(OfferModel offerModel)
        {
            _context.OfferModel.Add(offerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferModel", new { id = offerModel.Offer_ID }, offerModel);
        }


    }








}

