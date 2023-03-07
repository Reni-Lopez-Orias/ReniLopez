using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Entity
{
    class Actividades
    {
        public int IdActividad { set; get; }
        public DateTime CreateDate { set; get; }
        public int IdUsuario { set; get; }
        public string Actividad { set; get; }
    }
}
