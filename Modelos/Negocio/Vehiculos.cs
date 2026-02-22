using Modelos.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Negocio
{
    public class Vehiculos: DBContext<Vehiculos>
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Placa { get; set; }
    }
}
