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
    public class CoronaVaccinesController : ControllerBase
    {
        private readonly WebAPIHomeTask2Context _context;

        public CoronaVaccinesController(WebAPIHomeTask2Context context)
        {
            _context = context;
        }

        // GET: api/CoronaVaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoronaVaccine>>> GetCoronaVaccines()
        {
          if (_context.CoronaVaccines == null)
          {
              return NotFound();
          }
            return await _context.CoronaVaccines.ToListAsync();
        }

        // GET: api/CoronaVaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoronaVaccine>> GetCoronaVaccine(int id)
        {
          if (_context.CoronaVaccines == null)
          {
              return NotFound();
          }
            var coronaVaccine = await _context.CoronaVaccines.FindAsync(id);

            if (coronaVaccine == null)
            {
                return NotFound();
            }

            return coronaVaccine;
        }

        // PUT: api/CoronaVaccines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCoronaVaccine(int id, CoronaVaccine coronaVaccine)
        {
            if (id != coronaVaccine.CoronaVaccineId)
            {
                return BadRequest();
            }

            _context.Entry(coronaVaccine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoronaVaccineExists(id))
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

        // POST: api/CoronaVaccines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoronaVaccine>> PostCoronaVaccine(CoronaVaccine coronaVaccine)
        {
          if (_context.CoronaVaccines == null)
          {
              return Problem("Entity set 'WebAPIHomeTask2Context.CoronaVaccines'  is null.");
          }
            _context.CoronaVaccines.Add(coronaVaccine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoronaVaccineExists(coronaVaccine.CoronaVaccineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoronaVaccine", new { id = coronaVaccine.CoronaVaccineId }, coronaVaccine);
        }

        // DELETE: api/CoronaVaccines/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoronaVaccine(int id)
        {
            if (_context.CoronaVaccines == null)
            {
                return NotFound();
            }
            var coronaVaccine = await _context.CoronaVaccines.FindAsync(id);
            if (coronaVaccine == null)
            {
                return NotFound();
            }

            _context.CoronaVaccines.Remove(coronaVaccine);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool CoronaVaccineExists(int id)
        {
            return (_context.CoronaVaccines?.Any(e => e.CoronaVaccineId == id)).GetValueOrDefault();
        }
    }
}
