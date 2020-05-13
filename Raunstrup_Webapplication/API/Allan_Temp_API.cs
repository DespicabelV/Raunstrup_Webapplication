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
    public class Allan_Temp_API : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Allan_Temp_API(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Allan_Temp_API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomerModel()
        {
            return await _context.CustomerModel.ToListAsync();
        }

        // GET: api/Allan_Temp_API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerModel(int id)
        {
            var customerModel = await _context.CustomerModel.FindAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return customerModel;
        }

        // PUT: api/Allan_Temp_API/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerModel(int id, CustomerModel customerModel)
        {
            if (id != customerModel.Costumor_Id)
            {
                return BadRequest();
            }

            _context.Entry(customerModel).State = EntityState.Modified;

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

        // POST: api/Allan_Temp_API
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerModel(CustomerModel customerModel)
        {
            _context.CustomerModel.Add(customerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerModel", new { id = customerModel.Costumor_Id }, customerModel);
        }

        // DELETE: api/Allan_Temp_API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomerModel(int id)
        {
            var customerModel = await _context.CustomerModel.FindAsync(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            _context.CustomerModel.Remove(customerModel);
            await _context.SaveChangesAsync();

            return customerModel;
        }

        private bool CustomerModelExists(int id)
        {
            return _context.CustomerModel.Any(e => e.Costumor_Id == id);
        }
    }
}
