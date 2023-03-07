

using Backend.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Servicios
{
    public class UsuariosService
    {
        //metodo agrega usuarios
        public static RespuestaModel<List<UsuariosModel>> Agregar(UsuariosModel usuario, Contexto contexto, ILogger _logger)
        {
            try
            {
                UsuariosModel usuarioTemp = contexto.Usuarios.Where(x => x.Id.Equals(usuario.Id)).FirstOrDefault();

                if (usuarioTemp != null)
                {
                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                        MensajeUsuario = $"El usuario {usuario.Nombre} ya existe!"
                    };
                }

                List<UsuariosModel> respuesta = contexto.Usuarios.OrderByDescending(x => x.Id).ToList();
                respuesta.Insert(0,usuario);

                contexto.Usuarios.Add(usuario);
                contexto.SaveChangesAsync().Wait();
                    
                ActividadesService.GuardarActividad(usuario, "Creación de Usuario", contexto, _logger);

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = respuesta,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = $"El usuario fue agregado!"
                };

            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

        }

        //metodo edita usuarios
        public static RespuestaModel<List<UsuariosModel>> Editar(int id, UsuariosModel usuario, Contexto contexto, ILogger _logger)
        {
            try
            {
                UsuariosModel usuarioTemp = contexto.Usuarios.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (usuarioTemp == null)
                {
                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                        MensajeUsuario = "El usuario no existe!"
                    };
                }

                List<UsuariosModel> respuesta = contexto.Usuarios.OrderByDescending(x => x.Id).ToList();
                  
                contexto.Usuarios.Update(usuarioTemp);
                contexto.SaveChangesAsync().Wait();

                ActividadesService.GuardarActividad(usuario, "Actualización de Usuario", contexto, _logger);

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = respuesta,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = $"El usuario {usuario.Nombre} fue actualizado!"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

        }

        //metodo buscar por id de usuario
        public static RespuestaModel<List<UsuariosModel>> ObtenerUsuarios(Contexto contexto, ILogger _logger)   
        {
            try
            {
                List<UsuariosModel> usuarios = contexto.Usuarios.OrderByDescending(x=> x.Id).ToList();

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = usuarios,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = $"Listado de usuarios!"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

        }

        //metodo obtiene todos los usuarios
        public static RespuestaModel<List<UsuariosModel>> ObtenerUsuario(int id, Contexto contexto, ILogger _logger)
        {
            try
            {

                UsuariosModel usuario = contexto.Usuarios.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (usuario == null)
                {
                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                        MensajeUsuario = "El usuario no existe!"
                    };
                }

                string nombreUsuario = usuario.Nombre;

                List<UsuariosModel> respuesta = new List<UsuariosModel>();
                respuesta.Add(usuario);

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = respuesta,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = $"Datos del usuario!"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                };
            }

        }

        //metodo elimina usuario por id
        public static RespuestaModel<List<UsuariosModel>> EliminarUsuario(int id, Contexto contexto, ILogger _logger)
        {
            try
            {
                UsuariosModel usuario = contexto.Usuarios.Where(x => x.Id.Equals(id)).FirstOrDefault();
                List< UsuariosModel> respuesta = contexto.Usuarios.Where(x => x.Id != id).ToList();
                if (usuario == null)
                {
                    return new RespuestaModel<List<UsuariosModel>>
                    {
                        Respuesta = null,
                        CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                        MensajeUsuario = "El usuario no existe!"
                    };
                }

                contexto.Usuarios.Remove(usuario);
                contexto.SaveChangesAsync().Wait();

                ActividadesService.GuardarActividad(usuario, "Eliminación de Usuario", contexto, _logger);

                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = respuesta,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.EXITO),
                    MensajeUsuario = "Usuario eliminado!"
                };
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", _logger);
                return new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al eliminar el usuario"
                };
            }

        }
    }



}
