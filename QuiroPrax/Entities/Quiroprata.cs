using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuiroPrax.Entities
{
    public class Quiroprata : Usuario
    {
        public int NumeroABQ { get; set; }
        public string CpfCnpj { get; set; }
        public string Clinica { get; set; }
        public string LocalAtendimento {  get; set; }

        [AllowNull]
        public ICollection<Consulta> Consultas { get; set; }
    }
}
