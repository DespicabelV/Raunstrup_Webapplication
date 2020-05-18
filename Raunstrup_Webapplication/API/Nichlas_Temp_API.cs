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

        // GET: api/Nichlas_Temp_API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferModel>>> GetOfferModel()
        {
            return await _context.OfferModel.Include(c => c.Status).ToListAsync();
        }

        // GET: api/Nichlas_Temp_API/5
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

        // PUT: api/Nichlas_Temp_API/5
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
                if (!CustomerModelExists(id))
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

        // POST: api/Nichlas_Temp_API
        [HttpPost]
        public async Task<ActionResult<OfferModel>> PostOfferModel(OfferModel offerModel)
        {
            _context.OfferModel.Add(offerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferModel", new { id = offerModel.Offer_ID }, offerModel);
        }

        // DELETE: api/Nichlas_Temp_API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferModel>> DeleteOfferModel(int id)
        {
            var offerModel = await _context.OfferModel.FindAsync(id);
            if (offerModel == null)
            {
                return NotFound();
            }

            _context.OfferModel.Remove(offerModel);
            await _context.SaveChangesAsync();

            return offerModel;
        }

        private bool CustomerModelExists(int id)
        {
            return _context.CustomerModel.Any(e => e.Costumor_Id == id);
        }
    }
}
