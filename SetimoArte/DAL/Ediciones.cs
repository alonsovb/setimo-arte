using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utilerías;
using Utilerías.Objetos;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL {
    /// <summary>
    /// Acceso a los datos para editar
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>
    public class Ediciones {
        
        /// <summary>
        /// Método definido para modificar la información de los plazos
        /// </summary>
        /// <param name="individual"></param>
        /// <param name="dobleTriple"></param>
        /// <param name="múltiple"></param>
        public void EditarPlazos(int individual, int dobleTriple, int múltiple)
        {

            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.editar_plazos";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTindividual", DbType.Int32, individual);
                db.AddInParameter(dbCommand, "@INTdoble_triple", DbType.Int32, dobleTriple);
                db.AddInParameter(dbCommand, "@INTmultiple", DbType.Int32, múltiple);
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Método definido para modificar la información de los precios de los alquileres
        /// </summary>
        /// <param name="precios"></param>
        public void EditarPreciosAlquileres(DataTable precios)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.modificar_precios_alquileres";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            DbCommand dbCommand1 = db.GetStoredProcCommand(sqlCommand);
            DbCommand dbCommand2 = db.GetStoredProcCommand(sqlCommand);

            try
            {
                
                    db.AddInParameter(dbCommand, "@STRtipo", DbType.String, "individual");
                    db.AddInParameter(dbCommand, "@INTprecio_dvd", DbType.Int32, precios.Rows[0]["DVD"]);
                    db.AddInParameter(dbCommand, "@INTprecio_blueray", DbType.Int32, precios.Rows[0]["BlueRay"]);
                    db.AddInParameter(dbCommand, "@INTprecio_hddvd", DbType.Int32, precios.Rows[0]["HD"]);
                    db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                    db.ExecuteNonQuery(dbCommand);

                    db.AddInParameter(dbCommand1, "@STRtipo", DbType.String, "multiple");
                    db.AddInParameter(dbCommand1, "@INTprecio_dvd", DbType.Int32, precios.Rows[1]["DVD"]);
                    db.AddInParameter(dbCommand1, "@INTprecio_blueray", DbType.Int32, precios.Rows[1]["BlueRay"]);
                    db.AddInParameter(dbCommand1, "@INTprecio_hddvd", DbType.Int32, precios.Rows[1]["HD"]);
                    db.AddOutParameter(dbCommand1, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand1, "@strMessage", DbType.String, 250);

                    db.ExecuteNonQuery(dbCommand1);

                    db.AddInParameter(dbCommand2, "@STRtipo", DbType.String, "adicional");
                    db.AddInParameter(dbCommand2, "@INTprecio_dvd", DbType.Int32, precios.Rows[2]["DVD"]);
                    db.AddInParameter(dbCommand2, "@INTprecio_blueray", DbType.Int32, precios.Rows[2]["BlueRay"]);
                    db.AddInParameter(dbCommand2, "@INTprecio_hddvd", DbType.Int32, precios.Rows[2]["HD"]);
                    db.AddOutParameter(dbCommand2, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand2, "@strMessage", DbType.String, 250);

                    db.ExecuteNonQuery(dbCommand2);

                    if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                        throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());
                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Método definido para modificar la información de los precios de las ventas
        /// </summary>
        /// <param name="precioSocio"></param>
        /// <param name="precioParticular"></param>
        public void EditarPreciosVentas(int precioSocio, int precioParticular)
        {

            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.modificar_precios_ventas";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTprecio_socio", DbType.Int32, precioSocio);
                db.AddInParameter(dbCommand, "@INTprecio_particular", DbType.Int32, precioParticular);
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        ///  Marcar un alquiler como devuelto
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public DataTable DevolverAlquiler(Alquiler alquiler) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[modificar_alquileres]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_alquiler", DbType.Int32, Utilerías.Utilerías.ObtenerValor(alquiler.Id));
                db.AddInParameter(dbCommand, "@CHARdevuelto", DbType.Byte, Utilerías.Utilerías.ObtenerValor(alquiler.Devuelto));
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
