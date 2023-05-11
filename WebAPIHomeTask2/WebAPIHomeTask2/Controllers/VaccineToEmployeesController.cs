using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIHomeTask2.Data;
using WebAPIHomeTask2.Models;

namespace WebAPIHomeTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineToEmployeesController : ControllerBase
    {
        private readonly WebAPIHomeTask2Context _context;

        public VaccineToEmployeesController(WebAPIHomeTask2Context context)
        {
            _context = context;
        }

        // GET: api/VaccineToEmployees
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineToEmployee>>> GetVaccineToEmployees()
        {
          if (_context.VaccineToEmployees == null)
          {
              return NotFound();
          }
            return await _context.VaccineToEmployees.ToListAsync();
        }*/

        // GET: api/VaccineToEmployees/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<VaccineToEmployee>> GetVaccineToEmployee(int id)
        {
          if (_context.VaccineToEmployees == null)
          {
              return NotFound();
          }
            var vaccineToEmployee = await _context.VaccineToEmployees.FindAsync(id);

            if (vaccineToEmployee == null)
            {
                return NotFound();
            }

            return vaccineToEmployee;
        }*/

        // PUT: api/VaccineToEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineToEmployee(int id, VaccineToEmployee vaccineToEmployee)
        {
            if (id != vaccineToEmployee.CoronaVaccineId)
            {
                return BadRequest();
            }

            _context.Entry(vaccineToEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineToEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/VaccineToEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineToEmployee>> PostVaccineToEmployee(VaccineToEmployee vaccineToEmployee)
        {
            if (_context.VaccineToEmployees == null)
            {
                return Problem("Entity set 'WebAPIHomeTask2Context.VaccineToEmployees'  is null.");
            }
            
            //checks that the number of vaccines is not more or equal to 4
            if (_context.VaccineToEmployees.Where(c => c.EmployeeId == vaccineToEmployee.EmployeeId).Count<VaccineToEmployee>()>=4)
            {
                return Problem("Employee already has 4 vaccines.");
            }

            _context.VaccineToEmployees.Add(vaccineToEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VaccineToEmployeeExists(vaccineToEmployee.CoronaVaccineId, vaccineToEmployee.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVaccineToEmployee", new { id = vaccineToEmployee.CoronaVaccineId }, vaccineToEmployee);
        }

        // DELETE: api/VaccineToEmployees/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineToEmployee(int id)
        {
            if (_context.VaccineToEmployees == null)
            {
                return NotFound();
            }
            var vaccineToEmployee = await _context.VaccineToEmployees.FindAsync(id);
            if (vaccineToEmployee == null)
            {
                return NotFound();
            }

            _context.VaccineToEmployees.Remove(vaccineToEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool VaccineToEmployeeExists(int Vid, string Eid)
        {
            return (_context.VaccineToEmployees?.Any(e => e.CoronaVaccineId == Vid && e.EmployeeId==Eid)).GetValueOrDefault();
        }

    }
}
