using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilerías;
using Utilerías.Objetos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL {
    /// <summary>
    /// Acceso a datos para registrar
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>
    public class Registros {

        /// <summary>
        /// Método definido para registrar los datos de los socios
        /// </summary>
        /// <param name="DatosC"></param>
 
        public void RegistrarSocios(Cliente DatosC) {
            
            try
            {
            SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=proyectoWeb2; Integrated Security = SSPI;");
            SqlParameter param1 = new SqlParameter("@STRnombre", Utilerías.Utilerías.ObtenerValor(DatosC.Nombre));
            SqlParameter param2 = new SqlParameter("@STRapellidos", Utilerías.Utilerías.ObtenerValor(DatosC.Apellidos));
            SqlParameter param3 = new SqlParameter("@IMAfotografia", Utilerías.Utilerías.ObtenerValor(DatosC.Fotografía));
            param3.SqlDbType = SqlDbType.Image;
            SqlParameter param4 = new SqlParameter("@INTtelefono", Utilerías.Utilerías.ObtenerValor(DatosC.Teléfono));
            param4.SqlDbType = SqlDbType.Int;
            SqlParameter param5 = new SqlParameter("@STRemail", Utilerías.Utilerías.ObtenerValor(DatosC.Email));
            SqlParameter param6 = new SqlParameter("@STRdireccion", Utilerías.Utilerías.ObtenerValor(DatosC.Dirección));
            SqlParameter param7 = new SqlParameter("@DTfecha_afiliacion", Utilerías.Utilerías.ObtenerValor(DatosC.Afiliación));
            SqlParameter param8 = new SqlParameter("@INTestado", Utilerías.Utilerías.ObtenerValor(DatosC.Estado));
            SqlParameter param9 = new SqlParameter("@nStatus", 2);
            SqlParameter param10 = new SqlParameter("@strMessage", 250);

            SqlParameter[] SqlParams = new SqlParameter[]
                {param1,param2,param3,param4,param5,param6,param7,param8,param9,param10};
            SqlCommand Cmd = new SqlCommand("insertar_socios", conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(SqlParams);
            conn.Open();
            Cmd.ExecuteNonQuery();
            conn.Close();

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método definido para registrar los datos de las películas
        /// </summary>
        /// <param name="DatosA"></param>
        public void RegistrarPelículas(Película DatosA) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.insertar_peliculas";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try {
                db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosA.Nombre));
                db.AddInParameter(dbCommand, "@INTgenero", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.Género));
                db.AddInParameter(dbCommand, "@INTinventario_dvd", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.InvDVD));
                db.AddInParameter(dbCommand, "@INTinventario_blueray", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.InvBlueRay));
                db.AddInParameter(dbCommand, "@INTinventario_hddvd", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.InvHD));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método definido para registrar los datos de los géneros
        /// </summary>
        /// <param name="DatosG"></param>
        /// <returns></returns>
        public int RegistrarGéneros(Géneros DatosG) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_generos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosG.Nombre));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                db.AddOutParameter(dbCommand, "@INTid_genero", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return int.Parse(db.GetParameterValue(dbCommand, "@INTid_genero").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método definido para registrar los datos de los alquileres
        /// </summary>
        /// <param name="DatosA"></param>
        /// <param name="PelisAlquiladas"></param>
 
        public void RegistrarAlquileres(Alquiler DatosA, DataTable PelisAlquiladas)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_alquileres]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            using (DbConnection conn = db.CreateConnection()) // conexion para la transaccion
            {
                conn.Open(); //abrimos la conexion
                DbTransaction tranRegistro = conn.BeginTransaction(); //iniciamos la transaccion 

                if (PelisAlquiladas.Rows.Count == 0)
                {
                    throw new Exception("No se han seleccionado películas");
                }


                try
                {
                    db.AddInParameter(dbCommand, "@INTsocio", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.Socio));
                    db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.Utilerías.ObtenerValor(DatosA.Fecha));
                    db.AddInParameter(dbCommand, "@DTentrega", DbType.DateTime, Utilerías.Utilerías.ObtenerValor(DatosA.Entrega));
                    db.AddInParameter(dbCommand, "@INTcosto", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.Costo));
                    db.AddInParameter(dbCommand, "@INTplazo", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosA.Plazo));
                    db.AddInParameter(dbCommand, "@CHARdevuelto", DbType.Boolean, Utilerías.Utilerías.ObtenerValor(DatosA.Devuelto));

                    db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                    db.AddOutParameter(dbCommand, "@INTid_alquiler", DbType.Int32, 4);

                    db.ExecuteNonQuery(dbCommand, tranRegistro);


                    if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                        throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                    // Se registra la informacion del auto, un vez ingresados los datos personales
                    int idAlquiler = int.Parse(db.GetParameterValue(dbCommand, "@INTid_alquiler").ToString());

                    for (int i = 0; i < PelisAlquiladas.Rows.Count; i++)
                    {
                        AlquilerPelícula DatosAP = new AlquilerPelícula();
                        DatosAP.Alquiler = idAlquiler;
                        DatosAP.Película = Convert.ToInt32(PelisAlquiladas.Rows[i]["idPelículas"].ToString());
                        DatosAP.TotalDVD = Convert.ToInt32(PelisAlquiladas.Rows[i]["cantDVD"].ToString());
                        DatosAP.TotalBlueRay = Convert.ToInt32(PelisAlquiladas.Rows[i]["cantBlueRay"].ToString());
                        DatosAP.TotalHD = Convert.ToInt32(PelisAlquiladas.Rows[i]["cantHD"].ToString());

                        RegistrarAlquilerPelículas(DatosAP, tranRegistro, db);
                    }

                        
                    tranRegistro.Commit();

                }
                catch (Exception ex)
                {
                    tranRegistro.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close(); // cerrar la conexion
                }
            }
        }
        
        /// <summary>
        /// Método definido para asociar las películas asociadas a un alquiler
        /// </summary>
        /// <param name="DatosAP"></param>
        /// <param name="tran"></param>
        /// <param name="db"></param>
        public void RegistrarAlquilerPelículas(AlquilerPelícula DatosAP, DbTransaction tran, Database db)
        {
            string sqlCommand = "dbo.insertar_alquileres_peliculas";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try
            {
                db.AddInParameter(dbCommand, "@INTalquiler", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosAP.Alquiler));
                db.AddInParameter(dbCommand, "@INTpelicula", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosAP.Película));
                db.AddInParameter(dbCommand, "@INTtotal_dvd", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosAP.TotalDVD));
                db.AddInParameter(dbCommand, "@INTtotal_blueray", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosAP.TotalBlueRay));
                db.AddInParameter(dbCommand, "@INTtotal_hddvd", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosAP.TotalHD));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand, tran);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método definido para registrar los datos de los ventas
        /// </summary>
        /// <param name="DatosV"></param>
        /// <param name="PelisVendidas"></param>
        public void RegistrarVentas(Venta DatosV, DataTable PelisVendidas) 
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_ventas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            if (PelisVendidas.Rows.Count == 0)
            {
                throw new Exception("No existen películas seleccionadas");
            }

            using (DbConnection conn = db.CreateConnection()) // conexion para la transaccion
            {
                conn.Open(); //abrimos la conexion
                DbTransaction tranRegistro = conn.BeginTransaction(); //iniciamos la transaccion 

                try
                {
                    db.AddInParameter(dbCommand, "@INTcliente", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosV.Cliente));
                    db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.Utilerías.ObtenerValor(DatosV.Fecha));
                    db.AddInParameter(dbCommand, "@INTcosto", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosV.Costo));
                    
                    db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                    db.AddOutParameter(dbCommand, "@INTid_venta", DbType.Int32, 4);

                    db.ExecuteNonQuery(dbCommand, tranRegistro);


                    if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                        throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                    // Se registra la informacion del auto, un vez ingresados los datos personales
                    int idVenta = int.Parse(db.GetParameterValue(dbCommand, "@INTid_venta").ToString());

                    for (int i = 0; i < PelisVendidas.Rows.Count; i++)
                    {
                        VentaPelícula DatosVP = new VentaPelícula();
                        DatosVP.Venta = idVenta;
                        DatosVP.Película = Convert.ToInt32(PelisVendidas.Rows[i]["idPelículas"].ToString());
                        
                        RegistrarVentasPelículas(DatosVP, tranRegistro, db);
                    }


                    tranRegistro.Commit();

                }
                catch (Exception ex)
                {
                    tranRegistro.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close(); // cerrar la conexion
                }
            }
        }

        /// <summary>
        /// Método definido registrar las películas asocidas a ventas
        /// </summary>
        /// <param name="DatosVP"></param>
        /// <param name="tran"></param>
        /// <param name="db"></param>
        public void RegistrarVentasPelículas(VentaPelícula DatosVP, DbTransaction tran, Database db)
        {
            string sqlCommand = "dbo.insertar_ventas_peliculas";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try
            {
                db.AddInParameter(dbCommand, "@INTventa", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosVP.Venta));
                db.AddInParameter(dbCommand, "@INTpelicula", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosVP.Película));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand, tran);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
