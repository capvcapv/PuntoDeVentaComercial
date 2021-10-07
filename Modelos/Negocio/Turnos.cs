using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class Turnos
    {
        public int id { get; set; }
        public int caja { get; set; }
        public int empleado { get; set; }
        public DateTime fechaApertura { get; set; }
        public DateTime fechaCierre { get; set; }
        public int abierto { get; set; }

        public override string ToString()
        {
            var cajadato = CajasDBContext.obtener(caja);
            var usuario = UsuariosDBContext.obtener(empleado);
            return id.ToString() + " Caja : " + cajadato.nombre + " Usuario: " +  usuario.nombre + " Fecha Apertura: " + fechaApertura.ToShortDateString();
        }
    }

    public class TurnosDBContext
    {
        public static void guardar(Turnos a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Save("Turnos", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void actualizar(Turnos a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Update("Turnos", "Id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void eliminar(Turnos a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Delete("Turnos", "Id", null, a.id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static Turnos obtener(int id)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<Turnos>("select * from Turnos where id=" + id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        public static IEnumerable<Turnos> obtenerListado()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.Query<Turnos>("select * from Turnos order by id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static IEnumerable<Turnos> obtenerListadoAbiertos()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.Query<Turnos>("select * from Turnos where abierto=0 order by id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
