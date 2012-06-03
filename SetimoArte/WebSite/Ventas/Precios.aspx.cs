using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Utilerías.Objetos;

namespace WebSite {
    /// <summary>
    /// Obtiene los datos de interfaz
    /// Creada por Kenneth Sancho y Alonso Vega
    /// Estudiantes de Ing. Computacion
    /// Telefono: 87557833 y 85540554
    /// Email: kennethsancho@gmail.com
    ///        
    /// </summary>
    public partial class PreciosVentas : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();
        Ediciones insEdicionesBLL = new Ediciones();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                DataTable precio_venta = insConsultasBLL.ConsultarPrecioVenta();
                TBSocio.Text = precio_venta.Rows[0]["precio"].ToString();
                TBParticular.Text = precio_venta.Rows[1]["precio"].ToString();
            }
        }

        protected void BActualizar_Click(object sender, EventArgs e)
        {
            int precioSocio;
            int precioParticular;

            try { precioSocio = Convert.ToInt32(TBSocio.Text); }
            catch (Exception) { precioSocio = -1; }

            try { precioParticular = Convert.ToInt32(TBParticular.Text); }
            catch (Exception) { precioParticular = -1; }

            insEdicionesBLL.EditarPrecioVenta(precioSocio, precioParticular);
        }
    }
}