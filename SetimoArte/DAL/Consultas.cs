using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Utilerías;
using Utilerías.Objetos;

namespace DAL {

    /// <summary>
    /// Acceso a datos para consultas
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>
    public class Consultas {

        /// <summary>
        /// Método para consultar todos los géneros
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarGéneros() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_generos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los géneros por nombre de género
        /// </summary>
        /// <param name="DatosG"></param>
        /// <returns></returns>

        public DataTable ConsultarGénerosNombre(Géneros DatosG)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_generos_nombre]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "STRnombre", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosG.Nombre));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar las películas
        /// </summary>
        /// <param name="DatosP"></param>
        /// <returns></returns>
        public DataTable ConsultarPelículas(Película DatosP) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_peliculas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosP.Nombre));
                db.AddInParameter(dbCommand, "@INTid_pelicula", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosP.Id));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los socios registrados según el nombre o número de socio
        /// </summary>
        /// <param name="DatosC"></param>
        /// <returns></returns>
        public DataTable ConsultarSocios(Cliente DatosC)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_socios]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTnumero_socios", DbType.Int32, Utilerías.Utilerías.ObtenerValor(DatosC.NumeroSocio));
                db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosC.Nombre));
                db.AddInParameter(dbCommand, "@STRapellidos", DbType.String, Utilerías.Utilerías.ObtenerValor(DatosC.Apellidos));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los informes de alquileres
        /// </summary>
        /// <param name="DatosA"></param>
        /// <param name="CodSocio"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquileresFechas(Alquiler DatosA, int CodSocio)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alquileres_fecha]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@DTfecha_ini", DbType.DateTime, Utilerías.Utilerías.ObtenerValor(DatosA.Fecha));
                db.AddInParameter(dbCommand, "@DTfecha_fin", DbType.DateTime, Utilerías.Utilerías.ObtenerValor(DatosA.Entrega));
                db.AddInParameter(dbCommand, "@INTsocio", DbType.Int32, Utilerías.Utilerías.ObtenerValor(CodSocio));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los informes de las ventas por fecha
        /// </summary>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <param name="codSocio"></param>
        /// <returns></returns>
        public DataTable ConsultarVentasFechas(DateTime fechaIni, DateTime fechaFin, int codSocio)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_ventas_fecha]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@DTfecha_ini", DbType.DateTime, fechaIni);
                db.AddInParameter(dbCommand, "@DTfecha_fin", DbType.DateTime, fechaFin);
                db.AddInParameter(dbCommand, "@INTsocio", DbType.Int32,Utilerías.Utilerías.ObtenerValor(codSocio));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar todos los plazos de los alquileres
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPlazos()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_plazos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar todos los precios de los alquileres
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPreciosAlquileres()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_precios_alquileres]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar todos los precios de las ventas
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPreciosVentas()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_precios_ventas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        /// <summary>
        /// Método para consultar sí existen películas disponibles
        /// </summary>
        /// <param name="nombrePelícula"></param>
        /// <param name="tipoPelícula"></param>
        /// <returns></returns>
        public DataTable ConsultarDisponibles(string nombrePelícula, string tipoPelícula)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_inventario_peliculas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            if (tipoPelícula == "DVD")
                tipoPelícula = "inventario_dvd";
            else if (tipoPelícula == "BlueRay")
                tipoPelícula = "inventario_blueray";
            else
                tipoPelícula = "inventario_hddvd";

            try
            {
                db.AddInParameter(dbCommand, "@STRnombre", DbType.String, nombrePelícula);
                db.AddInParameter(dbCommand, "@STRtipo", DbType.String, tipoPelícula);
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar cuales alquileres están pendientes
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarAlquileresPendientes() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alquileres_pendientes]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar cuales alquileres están activos
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarAlquileresActivos() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alquileres_activos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar alquileres según el id
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquileresId(Alquiler alquiler) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alquileres_id]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_alquiler", DbType.Int32, Utilerías.Utilerías.ObtenerValor(alquiler.Id));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar las películas asociadas a un alquiler por id
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquileresPelículas(Alquiler alquiler) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alquileres_peliculas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_alquiler", DbType.Int32, Utilerías.Utilerías.ObtenerValor(alquiler.Id));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
