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
    public class TipoDeCitaController : ControllerBase
    {
        private readonly TipoDeCitaContext _context;

        public TipoDeCitaController(TipoDeCitaContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeCita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeCita>>> GetTipoDeCita()
        {
            return await _context.TipoDeCita.ToListAsync();
        }

        // GET: api/TipoDeCita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeCita>> GetTipoDeCita(int id)
        {
            var tipoDeCita = await _context.TipoDeCita.FindAsync(id);

            if (tipoDeCita == null)
            {
                return NotFound();
            }

            return tipoDeCita;
        }

        // PUT: api/TipoDeCita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeCita(int id, TipoDeCita tipoDeCita)
        {
            if (id != tipoDeCita.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeCita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeCitaExists(id))
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

        // POST: api/TipoDeCita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDeCita>> PostTipoDeCita(TipoDeCita tipoDeCita)
        {
            _context.TipoDeCita.Add(tipoDeCita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDeCita", new { id = tipoDeCita.ID }, tipoDeCita);
        }

        // DELETE: api/TipoDeCita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeCita(int id)
        {
            var tipoDeCita = await _context.TipoDeCita.FindAsync(id);
            if (tipoDeCita == null)
            {
                return NotFound();
            }

            _context.TipoDeCita.Remove(tipoDeCita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDeCitaExists(int id)
        {
            return _context.TipoDeCita.Any(e => e.ID == id);
        }
    }
}
