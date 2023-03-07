using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public virtual DbSet<UsuariosModel> Usuarios { get; set; }
        public virtual DbSet<ActividadesModel> Actividades { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosModel>().ToTable("usuarios");
            modelBuilder.Entity<ActividadesModel>().ToTable("actividades");

        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
