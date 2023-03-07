using Backend.Entidades;
using Backend.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly Contexto _contexto;
        private readonly ILogger<ActividadesController> _logger;

        public ActividadesController(Contexto contexto, ILogger<ActividadesController> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }
        [HttpGet]
        [Route("Actividades/Obtener")]
        public ActionResult<RespuestaModel<List<UsuariosModel>>> ObtenerUsuarios()
        {
            try
            {
                return Ok(ActividadesService.ObtenerActividades(this._contexto, this._logger));
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

    }
}
