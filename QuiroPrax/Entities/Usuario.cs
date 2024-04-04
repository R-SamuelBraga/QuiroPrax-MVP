using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;

namespace QuiroPrax.Entities
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public required string TipoUsuario { get; set; } // "Cliente" ou "Quiropraxia"
        
    }
}
