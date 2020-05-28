using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Raunstrup_Webapplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Offer_APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Offer_APIController(ApplicationDbContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public async Task<ActionResult<OfferModel>> PostOfferModel(OfferModel offerModel)
        {
            _context.OfferModel.Add(offerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferModel", new { id = offerModel.Offer_ID }, offerModel);
        }

        //Lavet af Nichlas og Allan
        [Produces("application/json")]
        [HttpGet("Search")]
        public IActionResult Search()
        {
            try
            {
                string Filter = HttpContext.Request.Query["Filter"].ToString();
                var Titel = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(Filter))
                    .Select(o => o.Offer_ID).ToList();
                return Ok(Titel);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OfferModel>> GetCustomerModel(int id)
        {
            var offerModel = await _context.OfferModel.FindAsync(id);

            if (offerModel == null)
            {
                return NotFound();
            }

            return offerModel;
        }

    }
}