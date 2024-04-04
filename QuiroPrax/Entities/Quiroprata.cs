using System.ComponentModel.DataAnnotations;

namespace QuiroPrax.Entities
{
    public class Quiroprata : Usuario
    {
        public int NumeroABQ { get; set; }
        public string CpfCnpj { get; set; }
        public string Clinica { get; set; }
        public string LocalAtendimento {  get; set; } 
        public bool AtendeDomicilio { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }
}
