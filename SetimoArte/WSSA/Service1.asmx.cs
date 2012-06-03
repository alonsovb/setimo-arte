using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Utilerías.Objetos;
using System.Data;

namespace WSSA
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        Consultas insConsultasDAL = new Consultas();
        Registros insRegistrosDAL = new Registros();


        [WebMethod]
        public DataTable ConsultarPelículas(int codPelícula, string nomPelícula)
        {
            try
            {
                Película nPelícula = new Película();
                nPelícula.Id = codPelícula;
                nPelícula.Nombre = nomPelícula;
                return insConsultasDAL.ConsultarPelículas(nPelícula);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod]
        public void RegistrarAlquiler(int codPelícula, int codSocio)
        {
            try
            {
                Cliente nCliente = new Cliente();
                nCliente.NumeroSocio = codSocio;
                DataTable socio = insConsultasDAL.ConsultarSocios(nCliente);

                if (socio.Rows.Count != 0)
                {
                    if (Convert.ToInt32(socio.Rows[0]["estado"]) == 1)
                        throw new Exception("El socio esta moroso");
                    return;
                }

                Alquiler nAlquiler = new Alquiler();
                nAlquiler.Socio = codSocio;
                nAlquiler.Plazo = 1;
                nAlquiler.Fecha = DateTime.Now;
                nAlquiler.Entrega = DateTime.Now.AddDays(2);
                nAlquiler.Costo = 1000;
                nAlquiler.Devuelto = false;


                DataTable pelisAlquiladas = new DataTable();
                pelisAlquiladas.Columns.Add("idPelículas");
                pelisAlquiladas.Columns.Add("cantDVD");
                pelisAlquiladas.Columns.Add("cantBlueRay");
                pelisAlquiladas.Columns.Add("cantHD");

                DataRow nRow = pelisAlquiladas.NewRow();
                nRow["idPelículas"] = codPelícula;
                nRow["cantDVD"] = 1;
                nRow["cantBlueRay"] = 0;
                nRow["cantHD"] = 0;
                pelisAlquiladas.Rows.Add(nRow);

                insRegistrosDAL.RegistrarAlquileres(nAlquiler,pelisAlquiladas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod]
        public void RegistrarVenta(int codPelícula, int codSocio)
        {
            try
            {
                Venta nVenta = new Venta();
                nVenta.Cliente = codSocio;
                nVenta.Costo = 1000;
                nVenta.Fecha = DateTime.Now;

                DataTable pelisVendidas = new DataTable();
                pelisVendidas.Columns.Add("idPelículas");
                
                DataRow nRow = pelisVendidas.NewRow();
                nRow["idPelículas"] = codPelícula;
                pelisVendidas.Rows.Add(nRow);

                insRegistrosDAL.RegistrarVentas(nVenta, pelisVendidas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}