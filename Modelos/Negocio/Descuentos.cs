using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelos.Utilerias;

namespace Modelos.Negocio
{
    public class Descuentos : DBContext<Descuentos>
    {
        public int id { get; set; } 
        public string prefijo { get; set; }
        public double descuento { get; set; }
    }
}
