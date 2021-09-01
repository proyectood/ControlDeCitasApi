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
    public class DepartamentoResponsableController : ControllerBase
    {
        private readonly DepartamentoResponsableContext _context;

        public DepartamentoResponsableController(DepartamentoResponsableContext context)
        {
            _context = context;
        }

        // GET: api/DepartamentoResponsable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoResponsable>>> GetDepartamentoResponsable()
        {
            return await _context.DepartamentoResponsable.ToListAsync();
        }

        // GET: api/DepartamentoResponsable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoResponsable>> GetDepartamentoResponsable(int id)
        {
            var departamentoResponsable = await _context.DepartamentoResponsable.FindAsync(id);

            if (departamentoResponsable == null)
            {
                return NotFound();
            }

            return departamentoResponsable;
        }

        // PUT: api/DepartamentoResponsable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentoResponsable(int id, DepartamentoResponsable departamentoResponsable)
        {
            if (id != departamentoResponsable.ID)
            {
                return BadRequest();
            }

            _context.Entry(departamentoResponsable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoResponsableExists(id))
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

        // POST: api/DepartamentoResponsable
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartamentoResponsable>> PostDepartamentoResponsable(DepartamentoResponsable departamentoResponsable)
        {
            _context.DepartamentoResponsable.Add(departamentoResponsable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamentoResponsable", new { id = departamentoResponsable.ID }, departamentoResponsable);
        }

        // DELETE: api/DepartamentoResponsable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamentoResponsable(int id)
        {
            var departamentoResponsable = await _context.DepartamentoResponsable.FindAsync(id);
            if (departamentoResponsable == null)
            {
                return NotFound();
            }

            _context.DepartamentoResponsable.Remove(departamentoResponsable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoResponsableExists(int id)
        {
            return _context.DepartamentoResponsable.Any(e => e.ID == id);
        }
    }
}
