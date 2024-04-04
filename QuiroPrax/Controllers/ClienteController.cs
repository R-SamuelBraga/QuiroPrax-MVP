using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuiroPrax.Context;
using QuiroPrax.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuiroPrax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ConsultaContext _contexto;

        public ClienteController(ConsultaContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _contexto.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _contexto.Clientes.Any(e => e.Id == id);
        }

        //    // POST api/<ClienteController>
        //    [HttpPost]
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<ClienteController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<ClienteController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        //}
    }
}
