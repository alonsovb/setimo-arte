using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilerías.Objetos;
using BLL;

namespace WebSite {
    /// <summary>
    /// Obtiene los datos de interfaz
    /// Creada por Kenneth Sancho y Alonso Vega
    /// Estudiantes de Ing. Computacion
    /// Telefono: 87557833 y 85540554
    /// Email: kennethsancho@gmail.com
    ///        
    /// </summary>
    public partial class InformesVentas : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaIni;
            DateTime fechaFin;
            int codigoSocio;

            try { codigoSocio = Convert.ToInt32(TBSocio.Text); }
            catch (Exception) { codigoSocio = -1; }

            fechaIni = CInicio.SelectedDate;
            fechaFin = CFinal.SelectedDate;

            DataTable InfoVentas = insConsultasBLL.ConsultarVentaFecha(fechaIni, fechaFin, codigoSocio);
            this.GVLista.DataSource = InfoVentas;
            this.GVLista.DataBind();
        }
    }
}