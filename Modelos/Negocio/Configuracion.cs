using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class Configuracion
    {
        public int id { get; set; }
        public string empresa { get; set; }
        public string rutaBinarios { get; set; }
        public string claveSello { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public byte[] logo { get; set; }
        public int imprime_ticket { get; set; }
    }

    public class ConfigurationDBContext
    {
        public static void guardar(Configuracion a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Save("Configuracion", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void actualizar(Configuracion a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Update("Configuracion", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static Configuracion obtener()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<Configuracion>("select * from Configuracion where id=1");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        //public static IEnumerable<Clientes> obtenerListado()
        //{
        //    try
        //    {
        //        var db = new PetaPoco.Database("bd");
        //        return db.Query<Clientes>("select * from Clientes order by nombre");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}
    }
}
