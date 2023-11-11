using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.Contexts;
using Trainee_3S_WebApi.ViewModel;

namespace Trainee_3S_WebApi.Repository
{
    public class SetorRepository
    {
        public List<Setore> GetAll()
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Setores.ToList();
            }
        }

        public Setore? GetById(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Setores.Where(c => c.IdSetor == id).FirstOrDefault();
            }
        }

        public void Save(SetorViewModel Setor)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                Setore c = new Setore();
                c.IdSetor = Setor.IdSetor;
                c.Titulo = Setor.Titulo;

                dbContext.Setores.Add(c);
                dbContext.SaveChanges();
            }
        }

        public void Update(Setore s, int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuarioEncontrado = dbContext.Setores.Where(c => c.IdSetor == id).FirstOrDefault();
                if (usuarioEncontrado != null)
                {
                    dbContext.Setores.Update(s);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuario = dbContext.Setores.Where(c => c.IdSetor == id).FirstOrDefault();
                if (usuario != null)
                {
                    dbContext.Setores.Remove(usuario);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

