using Modelos.Utilerias;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelos.Negocio
{
    [PrimaryKey("Id")]
    public class EnviosProgramados : DBContext<EnviosProgramados>
    {
        public int Id { get; set; }

        public string FolioEnvio { get; set; }

        public int Documento { get; set; }

        public int DirreccionEnvio { get; set; }

        public int Chofer { get; set; }

        public int Vehiculo { get; set; }

        public DateTime FechaProgramada { get; set; }

        public int Estado { get; set; } // 0 = Pendiente, 1 = Entregado

        public override string ToString()
        {
            return $"Folio: {FolioEnvio} - Documento: {Documento}";
        }
    }
}
