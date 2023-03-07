using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class RespuestaModel<T>
    {
        public string MensajeUsuario { get; set; }
        public int CodigoRespuesta { set; get; }
        public T Respuesta { get; set; }
    }
}
