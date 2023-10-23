using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class Cajas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int almacen { get; set; }
        public string conceptoFactura { get; set; }
        public string conceptoGlobal { get; set; }
        public string conceptoPedido { get; set; }
        public string conceptoRemision { get; set; }
        public string conceptoPedido2 { get; set; }
        public string conceptoCotizacion { get; set; }
        public string conceptoCotizacion2 { get; set; }
        public string nombre1 { get; set; }
        public string formato1 { get; set; }
        public string nombre2 { get; set; }
        public string formato2 { get; set; }
        public string nombre3 { get; set; }
        public string formato3 { get; set; }
        public string nombre4 { get; set; }
        public string formato4 { get; set; }
        public string nombre5 { get; set; }
        public string formato5 { get; set; }
        public string nombre6 { get; set; }
        public string formato6 { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }

    public class CajasDBContext
    {
        public static void guardar(Cajas a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Save("Cajas", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void actualizar(Cajas a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Update("Cajas", "Id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static void eliminar(Cajas a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Delete("Cajas", "Id", null,a.id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static Cajas obtener(int id)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<Cajas>("select * from Cajas where id=" + id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        public static IEnumerable<Cajas> obtenerListado()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.Query<Cajas>("select * from Cajas order by id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
