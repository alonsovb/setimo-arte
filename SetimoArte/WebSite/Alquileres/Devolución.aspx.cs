using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class AlquilerDevolución : System.Web.UI.Page {
        int id = -1;
        Alquiler alquiler;
        Consultas consultas = new Consultas();
        Ediciones ediciones = new Ediciones();
        DataTable DTalquiler;
        DataTable DTalquilerPelículas;
        
        protected void Page_Load(object sender, EventArgs e) {
            if (int.TryParse(Request.QueryString["id"], out id)) {
                if (id >= 0) {
                    alquiler = new Alquiler();
                    alquiler.Id = id;
                    DTalquiler = consultas.ConsultarAlquileresId(alquiler);
                    DTalquilerPelículas = consultas.ConsultarAlquileresPelículas(alquiler);
                    
                    GVAlquiler.DataSource = DTalquiler;
                    GVAlquiler.DataBind();
                    GVAlquilerPelícula.DataSource = DTalquilerPelículas;
                    GVAlquilerPelícula.DataBind();
                }
            }
        }

        protected void BDevolver_Click(object sender, EventArgs e) {
            if (alquiler != null) {
                alquiler.Devuelto = true;
                ediciones.DevolverAlquiler(alquiler);
                Response.Redirect("/Alquileres/Pendientes.aspx");
            }
        }
    }
}