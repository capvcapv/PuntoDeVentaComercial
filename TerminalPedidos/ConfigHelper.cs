using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TerminalPedidos
{
    public static class ConfigHelper
    {
        public static string ClonarConnectionStringConNuevoNombreBD(string nuevoNombreBD)
        {
            string nombreOrigen = "bd";
            string nombreNuevo = "comercial";

            // Cargar configuración
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var conexionOriginal = config.ConnectionStrings.ConnectionStrings[nombreOrigen];

            if (conexionOriginal == null)
                throw new Exception($"No se encontró la cadena de conexión '{nombreOrigen}'.");

            // Reemplazar solo la base de datos
            string cadenaOriginal = conexionOriginal.ConnectionString;
            string cadenaNueva = Regex.Replace(
                cadenaOriginal,
                @"(?i)(Database|Initial Catalog)\s*=\s*[^;]+",
                $"Database={nuevoNombreBD}");

            // Eliminar si ya existe
            if (config.ConnectionStrings.ConnectionStrings[nombreNuevo] != null)
                config.ConnectionStrings.ConnectionStrings.Remove(nombreNuevo);

            // Crear y agregar la nueva conexión
            var nuevaConexion = new ConnectionStringSettings(
                nombreNuevo,
                cadenaNueva,
                "System.Data.SqlClient"
            );
            config.ConnectionStrings.ConnectionStrings.Add(nuevaConexion);

            // Guardar cambios
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            // Devolver la cadena generada
            return cadenaNueva;
        }
    }
}
