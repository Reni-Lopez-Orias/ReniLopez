using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Entity; 

namespace Backend.Servicios

{
    public class UsuarioService
    {
        //meotodo agrega usurios
        public static RespuestaModel<List<UsuariosModel>> Agregar(UsuariosModel usuario, ILogger _logger)
        {
            try
            {
                if (usuario.Id == 0)
                {
                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = 0,
                        MensajeUsuario = $"El usuario {usuario.Nombre} {usuario.Apellido} fue agregado!"
                    };
                }
                else
                { 

                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = 1,
                        MensajeUsuario = $"El usuario {usuario.Nombre} {usuario.Apellido} fue actualizado!"
                    };
                }
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }



        }

        //metodo editda usuarios
        public static RespuestaModel<List<UsuariosModel>> Editar(int id, UsuariosModel usuario, ILogger _logger)
        {
            try
            {

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = $"El usuario {usuario.Nombre} {usuario.Apellido} fue actualizado!"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }



        }

        //metod0 buscar por id de usuario
        public static RespuestaModel<List<UsuariosModel>> ObternerUsuarios(ILogger _logger)
        {
            try
            { 
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 0,
                    MensajeUsuario = "Listado de usuarios!"
                }; 
                 
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

        }

        //metodo obtiene todos los usuarios
        public static RespuestaModel<List<UsuariosModel>> ObternerUsuario(int? id, ILogger _logger)
        {
            try
            { 
                string nombreUsuario = "prueba";

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = $"Datos del usuario {nombreUsuario}"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

         

        }

        //metodo elimina usuario por id
        public static RespuestaModel<List<UsuariosModel>> EliminarUsuario(int id, ILogger _logger)
        {
            try
            {  
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 0,
                    MensajeUsuario = "Usuario eliminado!"
                }; 
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = 1,
                    MensajeUsuario = "Ha ocurrido un error al eliminar el usuario"
                };
            }



        }
    }
}
