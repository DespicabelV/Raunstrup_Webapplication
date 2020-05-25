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
    public class ServiceLine_APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceLine_APIController(ApplicationDbContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public async Task<ActionResult<ServiceLineModel>> PostEmployeeOfferModel(ServiceLineModel serviceLineModel)
        {
            _context.ServiceLineModel.Add(serviceLineModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceLineModel", new { id = serviceLineModel.Service_Line_ID }, serviceLineModel);
        }
    }
}