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
    public class EstatusDeLaAtencionController : ControllerBase
    {
        private readonly EstatusDeLaAtencionContext _context;

        public EstatusDeLaAtencionController(EstatusDeLaAtencionContext context)
        {
            _context = context;
        }

        // GET: api/EstatusDeLaAtencion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstatusDeLaAtencion>>> GetEstatusDeLaAtencion()
        {
            return await _context.EstatusDeLaAtencion.ToListAsync();
        }

        // GET: api/EstatusDeLaAtencion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstatusDeLaAtencion>> GetEstatusDeLaAtencion(int id)
        {
            var estatusDeLaAtencion = await _context.EstatusDeLaAtencion.FindAsync(id);

            if (estatusDeLaAtencion == null)
            {
                return NotFound();
            }

            return estatusDeLaAtencion;
        }

        // PUT: api/EstatusDeLaAtencion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatusDeLaAtencion(int id, EstatusDeLaAtencion estatusDeLaAtencion)
        {
            if (id != estatusDeLaAtencion.ID)
            {
                return BadRequest();
            }

            _context.Entry(estatusDeLaAtencion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstatusDeLaAtencionExists(id))
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

        // POST: api/EstatusDeLaAtencion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstatusDeLaAtencion>> PostEstatusDeLaAtencion(EstatusDeLaAtencion estatusDeLaAtencion)
        {
            _context.EstatusDeLaAtencion.Add(estatusDeLaAtencion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstatusDeLaAtencion", new { id = estatusDeLaAtencion.ID }, estatusDeLaAtencion);
        }

        // DELETE: api/EstatusDeLaAtencion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstatusDeLaAtencion(int id)
        {
            var estatusDeLaAtencion = await _context.EstatusDeLaAtencion.FindAsync(id);
            if (estatusDeLaAtencion == null)
            {
                return NotFound();
            }

            _context.EstatusDeLaAtencion.Remove(estatusDeLaAtencion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstatusDeLaAtencionExists(int id)
        {
            return _context.EstatusDeLaAtencion.Any(e => e.ID == id);
        }
    }
}
