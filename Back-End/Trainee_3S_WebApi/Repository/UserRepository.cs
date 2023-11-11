using Trainee_3S_WebApi.Contexts;
using Trainee_3S_WebApi.Domains;

namespace Trainee_3S_WebApi.Repository
{
    public class UserRepository
    {
        public List<Usuario> GetUsers()
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.usuarios.ToList();
            }
        }

        public Usuario? GetUserById(int id)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.usuarios.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public void Save(Usuario user)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                 dbContext.usuarios.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void Update(Usuario user, int id)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                var usuarioEncontrado = dbContext.usuarios.Where(c => c.Id == id).FirstOrDefault();
                if(usuarioEncontrado != null)
                {
                    usuarioEncontrado.Tipo = user.Tipo;
                    usuarioEncontrado.Email = user.Email;
                    dbContext.usuarios.Update(usuarioEncontrado);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) { 
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                var usuario = dbContext.usuarios.Where(c => c.Id == id).FirstOrDefault();
                if(usuario != null)
                {
                    dbContext.usuarios.Remove(usuario);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
