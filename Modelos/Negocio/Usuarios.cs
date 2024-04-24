using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public int agente { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }

    public class UsuariosDBContext
    {
        public static void guardar(Usuarios a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Save("Usuarios", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void actualizar(Usuarios a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Update("Usuarios", "Id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void eliminar(Usuarios a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Delete("Usuarios", "Id", null, a.id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static Usuarios obtener(int id)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<Usuarios>("select * from Usuarios where id=" + id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        public static Usuarios obtenerPorNombre(string nombre)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<Usuarios>("select * from Usuarios where nombre='" + nombre + "'");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        public static IEnumerable<Usuarios> obtenerListado()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.Query<Usuarios>("select * from Usuarios order by id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
