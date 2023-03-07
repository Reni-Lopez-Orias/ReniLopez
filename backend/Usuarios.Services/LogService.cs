using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Servicios
{
    public class LogService
    {
        public static void RegistroLogs(Exception ex, string clase, ILogger _logger)
        {

            string error;
            DateTime fecha = new DateTime();
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            error = ex.Message;
            _logger.LogError($"Ha ocurrido en clase: {clase}, datos del error:{error}, fecha: {fecha}");

        }
    }
}
