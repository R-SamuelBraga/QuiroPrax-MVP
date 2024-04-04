using System.ComponentModel.DataAnnotations;

namespace QuiroPrax.Entities
{
    public class Cliente : Usuario
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<FormularioAdmissao> FormularioAdmissao { get; set; }
        public string Endereco { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
