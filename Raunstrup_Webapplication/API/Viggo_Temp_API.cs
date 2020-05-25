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
    [Route("api/ReportController")]
    [ApiController]
    public class Viggo_Temp_API : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Viggo_Temp_API(ApplicationDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------OfferModel API--------------------------------------------
        // PUT: api/Offer_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferModel(int id, OfferModel offerModel)
        {
            if (id != offerModel.Offer_ID)
            {
                return BadRequest();
            }

            _context.Entry(offerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/Offer_API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferModel>> GetOfferModel(int id)
        {
            var offerModel = await _context.OfferModel.FindAsync(id);

            if (offerModel == null)
            {
                return NotFound();
            }

            return offerModel;
        }

        // DELETE: api/Offer_API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferModel>> DeleteOfferModel(int id)
        {
            var OfferModel = await _context.OfferModel.FindAsync(id);
            if (OfferModel == null)
            {
                return NotFound();
            }

            _context.OfferModel.Remove(OfferModel);
            await _context.SaveChangesAsync();

            return OfferModel;
        }

        private bool OfferModelExists(int id)
        {
            return _context.OfferModel.Any(e => e.Offer_ID == id);
        }

        //---------------------------------------------ServiceLineModel API--------------------------------------------
        // PUT: api/ServiceLine_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceLineModel(int id, ServiceLineModel serviceLineModel)
        {
            if (id != serviceLineModel.Service_Line_ID)
            {
                return BadRequest();
            }

            _context.Entry(serviceLineModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceLineModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/ServiceLine_API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceLineModel>> GetServiceLineModel(int id)
        {
            var serviceLineModel = await _context.ServiceLineModel.FindAsync(id);

            if (serviceLineModel == null)
            {
                return NotFound();
            }

            return serviceLineModel;
        }

        private bool ServiceLineModelExists(int id)
        {
            return _context.ServiceLineModel.Any(e => e.Service_Line_ID == id);
        }

        //---------------------------------------------EmployeeOfferModel API--------------------------------------------
        // PUT: api/EmployeeOffer_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeOfferModel(int id, EmployeeOfferModel employeeOfferModel)
        {
            if (id != employeeOfferModel.EmployeeOffer_ID)
            {
                return BadRequest();
            }

            _context.Entry(employeeOfferModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeOfferModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/EmployeeOffer_API/5
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

        private bool EmployeeOfferModelExists(int id)
        {
            return _context.EmployeeOfferModel.Any(e => e.EmployeeOffer_ID == id);
        }
    }
}
