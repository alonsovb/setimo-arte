using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class PlazosAlquileres : System.Web.UI.Page {
        Ediciones insEdicionesBLL = new Ediciones();
        Consultas insConsultasBLL = new Consultas();

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack)
            {
                DataTable plazos;
                plazos = insConsultasBLL.ConsultarPlazo();
                if (plazos.Rows.Count != 0)
                {
                    TBIndividual.Text = plazos.Rows[0]["individual"].ToString();
                    TBDobleTriple.Text = plazos.Rows[0]["doble_triple"].ToString();
                    TBMúltiple.Text = plazos.Rows[0]["multiple"].ToString();
                }
            }
        }

        protected void BActualizar_Click(object sender, EventArgs e)
        {
            int individual;
            int dobleTriple;
            int múltiple;

            try { individual = Convert.ToInt32(TBIndividual.Text); }
            catch (Exception) { individual = -1; }
            try { dobleTriple = Convert.ToInt32(TBDobleTriple.Text); }
            catch (Exception) { dobleTriple = -1; }
            try { múltiple = Convert.ToInt32(TBMúltiple.Text); }
            catch (Exception) { múltiple = -1; }

            insEdicionesBLL.EditarPlazo(individual, dobleTriple, múltiple);
        }
    }
}