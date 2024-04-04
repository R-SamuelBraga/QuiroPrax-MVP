using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuiroPrax.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public Cliente Cliente { get; set; }
        public Quiroprata Quiroprata { get; set; }
    }
}
