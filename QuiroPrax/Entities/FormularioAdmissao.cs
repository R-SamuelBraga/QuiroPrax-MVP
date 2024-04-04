using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuiroPrax.Entities
{
    public class FormularioAdmissao
    {

        public int Id { get; set; }
        public string MotivoVisita { get; set; }
        public string CondicoesMedicas { get; set; }
        public string ProblemasSaude { get; set; }
        public bool Alergias { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public int IdCliente {  get; set; }
        public Cliente Cliente { get; set; }
    }
}