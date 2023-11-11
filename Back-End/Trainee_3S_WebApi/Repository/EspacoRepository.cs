using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.Contexts;
using Trainee_3S_WebApi.ViewModel;

namespace Trainee_3S_WebApi.Repository
{
    public class EspacoRepository
    {
        public List<Espaco> GetAll()
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Espacos.ToList();
            }
        }

        public Espaco? GetById(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Espacos.Where(c => c.IdEspaco  == id).FirstOrDefault();
            }
        }

        public void Save(EspacoViewModel espaco)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                Espaco e = new Espaco();
                e.Titulo = espaco.Titulo;
                dbContext.Espacos.Add(e);
                dbContext.SaveChanges();
            }
        }

        public void Update(Usuario user, int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuarioEncontrado = dbContext.Espacos.Where(c => c.IdEspaco == id).FirstOrDefault();
                if (usuarioEncontrado != null)
                {
                    dbContext.Espacos.Update(usuarioEncontrado);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuario = dbContext.Espacos.Where(c => c.IdEspaco == id).FirstOrDefault();
                if (usuario != null)
                {
                    dbContext.Espacos.Remove(usuario);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

