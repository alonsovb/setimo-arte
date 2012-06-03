using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite {
    /// <summary>
    /// Obtiene los datos de interfaz
    /// Creada por Kenneth Sancho y Alonso Vega
    /// Estudiantes de Ing. Computacion
    /// Telefono: 87557833 y 85540554
    /// Email: kennethsancho@gmail.com
    ///        
    /// </summary>
    public partial class Cliente : System.Web.UI.Page {
        int idCliente;
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["id"] != null) {
                if (int.TryParse(Request.QueryString["id"], out idCliente)) {
                    Page.Title = idCliente.ToString();
                }
            }
        }
    }
}