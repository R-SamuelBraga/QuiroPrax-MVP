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
    public class NotificacaoEmailController : ControllerBase
    {
        private readonly ConsultaContext _context;

        public NotificacaoEmailController(ConsultaContext context)
        {
            _context = context;
        }

        // GET: api/NotificacaoEmail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacaoEmail>>> GetNotificacoesEmail()
        {
            return await _context.NotificacoesEmail.ToListAsync();
        }

        // GET: api/NotificacaoEmail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacaoEmail>> GetNotificacaoEmail(int id)
        {
            var notificacaoEmail = await _context.NotificacoesEmail.FindAsync(id);

            if (notificacaoEmail == null)
            {
                return NotFound();
            }

            return notificacaoEmail;
        }

        // PUT: api/NotificacaoEmail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacaoEmail(int id, NotificacaoEmail notificacaoEmail)
        {
            if (id != notificacaoEmail.Id)
            {
                return BadRequest();
            }

            _context.Entry(notificacaoEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacaoEmailExists(id))
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

        // POST: api/NotificacaoEmail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotificacaoEmail>> PostNotificacaoEmail(NotificacaoEmail notificacaoEmail)
        {
            _context.NotificacoesEmail.Add(notificacaoEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacaoEmail", new { id = notificacaoEmail.Id }, notificacaoEmail);
        }

        // DELETE: api/NotificacaoEmail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacaoEmail(int id)
        {
            var notificacaoEmail = await _context.NotificacoesEmail.FindAsync(id);
            if (notificacaoEmail == null)
            {
                return NotFound();
            }

            _context.NotificacoesEmail.Remove(notificacaoEmail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacaoEmailExists(int id)
        {
            return _context.NotificacoesEmail.Any(e => e.Id == id);
        }
    }
}
