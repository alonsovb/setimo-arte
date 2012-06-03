using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
    public partial class InventarioPelícula : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //DataTable resultado = null;
            if (Request.QueryString["id"] != null) {
                string id = Request.QueryString["id"];
                // Buscar por id
            }
        }
    }
}