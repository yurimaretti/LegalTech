using StartupOne.Api.AspNet.Models;
using StartupOne.Api.AspNet.Repository.Context;
using System.Linq;

namespace StartupOne.Api.AspNet.Repository
{
    public class PrestadorRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public PrestadorRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<PrestadorModel> Listar()
        {
            var lista = new List<PrestadorModel>();

            lista = dataBaseContext
                    .Prestador
                    .ToList<PrestadorModel>();

            return lista;
        }

        public PrestadorModel Buscar(string id)
        {
            var prestador = dataBaseContext
                    .Prestador
                    .Find(id);

            return prestador;
        }

        public void Inserir(PrestadorModel prestador)
        {
            dataBaseContext.Prestador.Add(prestador);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(PrestadorModel prestador)
        {
            dataBaseContext.Prestador.Update(prestador);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(string id)
        {
            var prestador = new PrestadorModel(id);

            dataBaseContext.Prestador.Remove(prestador);
            dataBaseContext.SaveChanges();
        }
    }
}
