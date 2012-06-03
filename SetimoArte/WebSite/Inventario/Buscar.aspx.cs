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
    public partial class BuscarInventario : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();

        protected void Page_Load(object sender, EventArgs e) {
            DataTable resultado = new DataTable();
            /*if (Request.QueryString["id"] != null) {
                string id = Request.QueryString["id"];
                // Buscar por id
            } else if (Request.QueryString["nombre"] != null) {
                string nombre = Request.QueryString["nombre"];
                LBuscar.Text = "Resultados para películas con <i>" + nombre + "</i>";
                // Buscar por nombre
            }
            Película nPelícula = new Película();
            nPelícula.Id = -1;
            nPelícula.Nombre = "";
            resultado = insConsultasBLL.Consultarpelículas(nPelicula);
            GVLista.DataSource = resultado;
            GVLista.DataBind();*/
        }

        protected void BBuscar_Click(object sender, EventArgs e) {

            int código;

            // Convertir el código de película
            try { código = Convert.ToInt32(TBCódigo.Text); }
            catch (Exception) { código = -1; }

            // Buscar la película y mostrarla
            Película nPelícula = new Película();
            nPelícula.Id = código;
            nPelícula.Nombre = TBNombre.Text;
            GVLista.DataSource = insConsultasBLL.ConsultarPelícula(nPelícula);
            GVLista.DataBind();
        }
    }
}