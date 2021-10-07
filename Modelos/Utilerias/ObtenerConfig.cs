using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Utilerias
{
    public class ObtenerConfig
    {
        public static ConfiguracionConexion obtenerDatosSQL(string pCadena)
        {
            string[] cadenaCon = pCadena.Split(';');

            ConfiguracionConexion config = new ConfiguracionConexion();
            config.servidor = cadenaCon[0].Replace("Server=", "").Trim();
            config.empresa = cadenaCon[1].Replace("Database=", "").Trim();
            config.usuario = cadenaCon[2].Replace("User Id=", "").Trim();
            config.clave = cadenaCon[3].Replace("Password=", "").Trim();

            return config;
        }

        public static object obtenerDatosSQL(object p)
        {
            throw new NotImplementedException();
        }
    }
}
