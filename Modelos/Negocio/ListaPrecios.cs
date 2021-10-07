using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Negocio
{
    public class ListaPrecios
    {
        public int id { get; set; }
        public int producto { get; set; }
        public int lista { get; set; }
        public int unidad1 { get; set; }
        public double precio1 { get; set; }
        public int unidad2 { get; set; }
        public double precio2 { get; set; }
        public int unidad3 { get; set; }
        public double precio3 { get; set; }
        public int unidad4 { get; set; }
        public double precio4 { get; set; }
        public int unidad5 { get; set; }
        public double precio5 { get; set; }
        public int unidad6 { get; set; }
        public double precio6 { get; set; }
        public int unidad7 { get; set; }
        public double precio7 { get; set; }
        public int unidad8 { get; set; }
        public double precio8 { get; set; }
        public int unidad9 { get; set; }
        public double precio9 { get; set; }
        public int unidad10 { get; set; }
        public double precio10 { get; set; }
    }

    public static class ListaPreciosContextDB
    {
        public static void guardar(ListaPrecios a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Save("ListaPrecios", "id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                }
            }

        public static void actualizar(ListaPrecios a)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Update("ListaPrecios", "Id", a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public static ListaPrecios obtener(int idProducto,int lista)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.SingleOrDefault<ListaPrecios>("select * from ListaPrecios where producto=" + idProducto + " and lista=" + lista);

            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;

                }
        }

        public static void eliminarListaProducto(int producto)
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                db.Execute("delete from ListaPrecios where producto=" + producto);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static IEnumerable<ListaPrecios> obtenerListadoAgrupado()
        {
            try
            {
                var db = new PetaPoco.Database("bd");
                return db.Query<ListaPrecios>("select * from ListaPrecios");
            }
                catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                return null;
                }
        }
    }
}
