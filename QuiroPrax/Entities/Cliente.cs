using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuiroPrax.Entities
{
    public class Cliente : Usuario
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        [AllowNull]
        public FormularioAdmissao FormularioAdmissao { get; set; }
        public string Endereco { get; set; }

        [AllowNull]
        public ICollection<Consulta> Consultas { get; set; }
    }
}
