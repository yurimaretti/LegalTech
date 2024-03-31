using Microsoft.EntityFrameworkCore;
using StartupOne.Api.AspNet.Models;
using StartupOne.Api.AspNet.Repository.Context;
using System.Linq;

namespace StartupOne.Api.AspNet.Repository
{
    public class ServicoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ServicoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<ServicoModel> Listar()
        {
            var lista = new List<ServicoModel>();

            lista = dataBaseContext
                    .Servico
                    .ToList<ServicoModel>();

            return lista;
        }

        public ServicoModel Buscar(int id)
        {
            var servico = dataBaseContext
                    .Servico
                    .Find(id);

            return servico;
        }

        public void Inserir(ServicoModel servico)
        {
            dataBaseContext.Servico.Add(servico);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(ServicoModel servico)
        {
            dataBaseContext.Servico.Update(servico);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var servico = new ServicoModel { Id = id};

            dataBaseContext.Servico.Remove(servico);
            dataBaseContext.SaveChanges();
        }
    }
}
