using Microsoft.EntityFrameworkCore;
using Trainee_3S_WebApi.Domains;

namespace Trainee_3S_WebApi.Contexts
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<AcessoEspaco> acessoEspacos { get; set; }
        public DbSet<Colaborador> colaboradores { get; set; }
        public DbSet<Espaco> espacos { get; set; }
        public DbSet<Ponto> pontos { get; set; }
        public DbSet<Setor> setores { get; set; }
        public DbSet<TipoUsuario> tipoUsuarios { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Visitante> visitantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=ACCESS_3S;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcessoEspaco>(c =>
            {
                c.HasKey(e => e.Id);

                c.HasOne(c => c.Usuario).WithMany(u => u.AcessoEspacos).HasForeignKey(c => c.IdUsuario);

                c.HasOne(c => c.Espaco).WithMany(s => s.Acessos).HasForeignKey(c => c.IdEspaco);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
