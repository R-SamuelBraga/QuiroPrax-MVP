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
    public class FormularioAdmissaoController : ControllerBase
    {
        private readonly ConsultaContext _context;

        public FormularioAdmissaoController(ConsultaContext context)
        {
            _context = context;
        }

        // GET: api/FormularioAdmissao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormularioAdmissao>>> GetFormulariosAdmissao()
        {
            return await _context.FormulariosAdmissao.ToListAsync();
        }

        // GET: api/FormularioAdmissao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormularioAdmissao>> GetFormularioAdmissao(int id)
        {
            var formularioAdmissao = await _context.FormulariosAdmissao.FindAsync(id);

            if (formularioAdmissao == null)
            {
                return NotFound();
            }

            return formularioAdmissao;
        }

        // PUT: api/FormularioAdmissao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormularioAdmissao(int id, FormularioAdmissao formularioAdmissao)
        {
            if (id != formularioAdmissao.Id)
            {
                return BadRequest();
            }

            _context.Entry(formularioAdmissao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioAdmissaoExists(id))
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

        // POST: api/FormularioAdmissao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormularioAdmissao>> PostFormularioAdmissao(FormularioAdmissao formularioAdmissao)
        {
            _context.FormulariosAdmissao.Add(formularioAdmissao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormularioAdmissao", new { id = formularioAdmissao.Id }, formularioAdmissao);
        }

        // DELETE: api/FormularioAdmissao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormularioAdmissao(int id)
        {
            var formularioAdmissao = await _context.FormulariosAdmissao.FindAsync(id);
            if (formularioAdmissao == null)
            {
                return NotFound();
            }

            _context.FormulariosAdmissao.Remove(formularioAdmissao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormularioAdmissaoExists(int id)
        {
            return _context.FormulariosAdmissao.Any(e => e.Id == id);
        }
    }
}
