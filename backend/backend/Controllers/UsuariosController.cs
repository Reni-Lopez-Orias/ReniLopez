using Backend.Entidades;
using Backend.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly Contexto _contexto;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(Contexto contexto, ILogger<UsuariosController> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        [HttpPost]
        [Route("Agregar")]
        public ActionResult<RespuestaModel<UsuariosModel>> Agregar([FromBody] UsuariosModel usuario)
        {
            try
            {
                return Ok(UsuariosService.Agregar(usuario, this._contexto, this._logger));
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", this._logger);
                return Ok(new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = $"Ha ocurrido un error al enviar los datos del usuario {usuario.Nombre}"
                });
            }
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public ActionResult<RespuestaModel<List<UsuariosModel>>> Editar([FromBody] UsuariosModel usuario,int id)
        {
            try
            {
                return Ok(UsuariosService.Editar(id,usuario, this._contexto, this._logger));
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", this._logger);
                return Ok(new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = $"Ha ocurrido un error al enviar los datos del usuario {usuario.Nombre}"
                });
            }
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public ActionResult<RespuestaModel<List<UsuariosModel>>> ObtenerUsuarios()
        {
            try
            {
                return Ok(UsuariosService.ObtenerUsuarios(this._contexto, this._logger));
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", this._logger);
                return Ok(new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                });
            }
        }

        [HttpGet]
        [Route("ObtenerUsuario/{id}")]
        public ActionResult<RespuestaModel<List<UsuariosModel>>> ObtenerUsuario(int id)
        {
            try
            {
                return Ok(UsuariosService.ObtenerUsuario(id, this._contexto, this._logger));
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", this._logger);
                return Ok(new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al obtener los datos del usuario"
                });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public ActionResult<RespuestaModel<List<UsuariosModel>>> EliminarUsuario(int id)
        {
            try
            {
                return Ok(UsuariosService.EliminarUsuario(id, this._contexto, this._logger));
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "UsuarioController", this._logger);
                return Ok(new RespuestaModel<List<UsuariosModel>>
                {
                    Respuesta = null,
                    CodigoRespuesta = ((int)Backend.Entidades.CodigoEstado.ERROR),
                    MensajeUsuario = "Ha ocurrido un error al eliminar los datos del usuario"
                });
            }
        }
    }
}
