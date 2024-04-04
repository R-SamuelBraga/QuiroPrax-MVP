using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuiroPrax.Context;
using QuiroPrax.Entities;

namespace QuiroPrax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuiroprataController : ControllerBase
    {
        private readonly ConsultaContext _contexto;

        public QuiroprataController(ConsultaContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Quiroprata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiroprata>>> GetQuiropratas()
        {
            return await _contexto.Quiropratas.ToListAsync();
        }

        // GET: api/Quiroprata/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiroprata>> GetQuiroprata(int id)
        {
            var quiroprata = await _contexto.Quiropratas.FindAsync(id);

            if (quiroprata == null)
            {
                return NotFound();
            }

            return quiroprata;
        }

        // PUT: api/Quiroprata/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiroprata(int id, Quiroprata quiroprata)
        {
            if (id != quiroprata.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(quiroprata).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuiroprataExists(id))
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

        // POST: api/Quiroprata
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quiroprata>> PostQuiroprata(Quiroprata quiroprata)
        {
            _contexto.Quiropratas.Add(quiroprata);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetQuiroprata", new { id = quiroprata.Id }, quiroprata);
        }

        // DELETE: api/Quiroprata/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiroprata(int id)
        {
            var quiroprata = await _contexto.Quiropratas.FindAsync(id);
            if (quiroprata == null)
            {
                return NotFound();
            }

            _contexto.Quiropratas.Remove(quiroprata);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool QuiroprataExists(int id)
        {
            return _contexto.Quiropratas.Any(e => e.Id == id);
        }
    }
}
