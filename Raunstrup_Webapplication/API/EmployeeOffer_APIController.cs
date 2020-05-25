using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeOffer_APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeOffer_APIController(ApplicationDbContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public async Task<ActionResult<EmployeeOfferModel>> PostEmployeeOfferModel(EmployeeOfferModel employeeOfferModel)
        {
            _context.EmployeeOfferModel.Add(employeeOfferModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeOfferModel", new { id = employeeOfferModel.EmployeeOffer_ID }, employeeOfferModel);
        }
    }
}