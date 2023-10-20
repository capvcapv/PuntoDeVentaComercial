using PetaPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Utilerias
{
    public class DBContext<T>
    {
        private Database db;
        public T obtenerId(int pId, string conexion = "bd")
        {
            try
            {
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db = new PetaPoco.Database(conexion);
                }

                return db.SingleOrDefault<T>(pId);

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public List<T> obtenerTodos(string conexion = "bd")
        {
            try
            {
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db = new PetaPoco.Database(conexion);
                }

                return db.Query<T>().ToList<T>();

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public List<T> obtenerSQL(string pSql, string conexion = "bd")
        {
            try
            {
                
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db= new PetaPoco.Database(conexion);
                }

                return db.Query<T>(pSql).ToList<T>();

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public void guardar(string conexion = "bd")
        {
            try
            {
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db = new PetaPoco.Database(conexion);
                }

                db.Save(this);

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);

            }
        }

        public void actualizar(string conexion = "bd")
        {
            try
            {
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db = new PetaPoco.Database(conexion);
                }

                db.Update(this);

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void elimina(string conexion = "bd")
        {
            try
            {
                if (conexion != "bd")
                {
                    db = new PetaPoco.Database(conexion, "System.Data.SqlClient");
                }
                else
                {
                    db = new PetaPoco.Database(conexion);
                }

                db.Delete(this);

            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
