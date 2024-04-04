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
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaContext _contexto;

        public ConsultaController(ConsultaContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Consulta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
        {
            return await _contexto.Consultas.ToListAsync();
        }

        // GET: api/Consulta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> GetConsulta(int id)
        {
            var consulta = await _contexto.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return consulta;
        }

        // PUT: api/Consulta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulta(int id, Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(consulta).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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

        // POST: api/Consulta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consulta>> PostConsulta(Consulta consulta)
        {
            _contexto.Consultas.Add(consulta);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("GetConsulta", new { id = consulta.Id }, consulta);
        }

        // DELETE: api/Consulta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consulta = await _contexto.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _contexto.Consultas.Remove(consulta);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultaExists(int id)
        {
            return _contexto.Consultas.Any(e => e.Id == id);
        }
    }
}
