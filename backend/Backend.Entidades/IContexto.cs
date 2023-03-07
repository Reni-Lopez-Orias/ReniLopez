using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public interface IContexto
    {
        DbSet<UsuariosModel> Usuarios { get; set; }
        DbSet<ActividadesModel> Actividades { get; set; }
        Task<int> SaveChanges();
    }
}
