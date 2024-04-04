using Microsoft.EntityFrameworkCore;
using QuiroPrax.Entities;

namespace QuiroPrax.Context
{
    public class ConsultaContext : DbContext
    {
        public ConsultaContext(DbContextOptions<ConsultaContext> options) : base(options)
        {
           // modelBuilder.Entity<Cliente>()
           //.HasOne(a => a.FormularioAdmissao)
           //.WithOne(a => a.Cliente)
           //.HasForeignKey<FormularioAdmissao>(c => c.ClienteID);

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<FormularioAdmissao> FormulariosAdmissao { get; set; }
        public DbSet<Quiroprata> Quiropratas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<NotificacaoEmail> NotificacoesEmail { get; set; }

    }
}
