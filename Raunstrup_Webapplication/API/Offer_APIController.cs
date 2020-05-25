using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;
using System.Linq;
using System.Threading.Tasks;

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
    }
}