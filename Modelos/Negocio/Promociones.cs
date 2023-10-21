using Modelos.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class Promociones: DBContext<Promociones>
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public int id_clasificacion1 { get; set; }
        public string clasificacion1 { get; set; }
        public double descuento { get; set; }
        public double cantidad { get; set; }

    }
}
