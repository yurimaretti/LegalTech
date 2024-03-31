using Microsoft.EntityFrameworkCore;
using StartupOne.Api.AspNet.Models;

namespace StartupOne.Api.AspNet.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        // Propriedade que será responsável pelo acesso a tabela de Prestador
        public DbSet<PrestadorModel> Prestador { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Usuário
        public DbSet<UsuarioModel> Usuario { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Serviço
        public DbSet<ServicoModel> Servico { get; set; }

        //Construtores
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }
    }
}
