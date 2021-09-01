using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlDeCitas.Models;

namespace ControlDeCitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        private readonly ResponsableContext _context;

        public ResponsableController(ResponsableContext context)
        {
            _context = context;
        }

        // GET: api/Responsable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsable>>> GetResponsable()
        {
            return await _context.Responsable.ToListAsync();
        }

        // GET: api/Responsable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsable>> GetResponsable(int id)
        {
            var responsable = await _context.Responsable.FindAsync(id);

            if (responsable == null)
            {
                return NotFound();
            }

            return responsable;
        }

        // PUT: api/Responsable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsable(int id, Responsable responsable)
        {
            if (id != responsable.ID)
            {
                return BadRequest();
            }

            _context.Entry(responsable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsableExists(id))
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

        // POST: api/Responsable
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Responsable>> PostResponsable(Responsable responsable)
        {
            _context.Responsable.Add(responsable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponsable", new { id = responsable.ID }, responsable);
        }

        // DELETE: api/Responsable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsable(int id)
        {
            var responsable = await _context.Responsable.FindAsync(id);
            if (responsable == null)
            {
                return NotFound();
            }

            _context.Responsable.Remove(responsable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponsableExists(int id)
        {
            return _context.Responsable.Any(e => e.ID == id);
        }
    }
}
