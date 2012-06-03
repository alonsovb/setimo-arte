using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilerías.Objetos;
using BLL;
using System.Data;


namespace WebSite {
    /// <summary>
    /// Obtiene los datos de interfaz
    /// Creada por Kenneth Sancho y Alonso Vega
    /// Estudiantes de Ing. Computacion
    /// Telefono: 87557833 y 85540554
    /// Email: kennethsancho@gmail.com
    ///        
    /// </summary>
    public partial class PreciosAlquileres : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();
        Ediciones insEdicionesBLL = new Ediciones();
        static DataTable ActPrecios = new DataTable();
        static bool crear = true;

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack)
            {
                DataTable precios = insConsultasBLL.ConsultarPrecioAlquiler();
                // carga los precios individuales
                TBIndividualDVD.Text = precios.Rows[0]["DVD"].ToString();
                TBIndividualBR.Text = precios.Rows[0]["BlueRay"].ToString();
                TBIndividualHD.Text = precios.Rows[0]["HD"].ToString();
                // carga los precios multiples
                TBMultipleDVD.Text = precios.Rows[1]["DVD"].ToString();
                TBMultipleBR.Text = precios.Rows[1]["BlueRay"].ToString();
                TBMultipleHD.Text = precios.Rows[1]["HD"].ToString();
                // carga los precios adicionales
                TBAdicionalDVD.Text = precios.Rows[2]["DVD"].ToString();
                TBAdicionalBR.Text = precios.Rows[2]["BlueRay"].ToString();
                TBAdicionalHD.Text = precios.Rows[2]["HD"].ToString();

                // construimos las columnas de la tabla
                if (crear)
                {
                    ActPrecios.Columns.Add("DVD");
                    ActPrecios.Columns.Add("BlueRay");
                    ActPrecios.Columns.Add("HD");
                    crear=false;
                }
            }

        }

        protected void BActualizar_Click(object sender, EventArgs e)
        {
            // Datos de los precios individuales
            DataRow nRowIndividual = ActPrecios.NewRow();
            nRowIndividual["DVD"] = TBIndividualDVD.Text;
            nRowIndividual["BlueRay"] = TBIndividualBR.Text;
            nRowIndividual["HD"] = TBIndividualHD.Text;
            ActPrecios.Rows.Add(nRowIndividual);

            // Datos de los precios multiple
            DataRow nRowMultiple = ActPrecios.NewRow();
            nRowMultiple["DVD"] = TBMultipleDVD.Text;
            nRowMultiple["BlueRay"] = TBMultipleBR.Text;
            nRowMultiple["HD"] = TBMultipleHD.Text;
            ActPrecios.Rows.Add(nRowMultiple);

            // Datos de los precios adicional
            DataRow nRowAdicional = ActPrecios.NewRow();
            nRowAdicional["DVD"] = TBAdicionalDVD.Text;
            nRowAdicional["BlueRay"] = TBAdicionalBR.Text;
            nRowAdicional["HD"] = TBAdicionalHD.Text;
            ActPrecios.Rows.Add(nRowAdicional);

            insEdicionesBLL.EditarPrecioAlquiler(ActPrecios);
            ActPrecios.Rows.Remove(nRowIndividual);
            ActPrecios.Rows.Remove(nRowMultiple);
            ActPrecios.Rows.Remove(nRowAdicional);


        }
    }
}