using Modelos.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Negocio
{
    public class EnviosProgramados:DBContext<EnviosProgramados>
    {
        public int Id { get; set; }

        public int Documento { get; set; }

        public int DirreccionEnvio { get; set; }

        public DateTime FechaProgramada { get; set; }

        public int Chofer { get; set; }

        public int Vehiculo { get; set; }
    }
}
