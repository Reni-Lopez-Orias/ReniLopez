using Backend.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Servicios
{
    public class ActividadesService
    {
        //metodo trae el listado de actividades
        public static RespuestaModel<List<ActividadesModel>> ObtenerActividades(Contexto contexto, ILogger _logger)
        {
            try
            {
                List<ActividadesModel> Actividades = contexto.Actividades.Include(x => x.Usuario).OrderByDescending(x => x.CreateDate).ToList();
                
                return new RespuestaModel<List<ActividadesModel>>
                {
                    Respuesta = Actividades,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = "Listado de Actividades!"
                };

            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<ActividadesModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener las actividades"
                };
            }

        }

        public static void GuardarActividad(UsuariosModel usuario, string _actividad, Contexto contexto, ILogger _logger)
        {

            try
            {
                ActividadesModel actividad = new ActividadesModel()
                {
                    CreateDate = DateTime.Now,
                    Usuario = usuario,
                    IdUsuario = (int)usuario.Id,
                    Actividad = _actividad
                };

                contexto.Actividades.Add(actividad);
                contexto.SaveChangesAsync().Wait();
            }
            catch(Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
            }
        }

    }
}
