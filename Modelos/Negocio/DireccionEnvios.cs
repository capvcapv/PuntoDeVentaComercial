using Modelos.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Negocio
{
    public class DireccionEnvios : DBContext<DireccionEnvios>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
