using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class RegistrarInventario : System.Web.UI.Page {
         Registros insRegistroBLL = new Registros();
         Consultas insConsultasBLL = new Consultas();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                DLCategoría.DataTextField = "nombre";
                DLCategoría.DataValueField = "nombre";
                DLCategoría.DataSource = insConsultasBLL.ConsultarGénero();
                DLCategoría.DataBind();
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombre.Text;
            string genero = DLCategoría.SelectedValue;
            int invDVD;
            int invBR;
            int invHD;

            try { invDVD = Convert.ToInt32(TBDVDs.Text); }
            catch (Exception) { invDVD = -1; }

            try { invBR = Convert.ToInt32(TBBRs.Text); }
            catch (Exception) { invBR = -1; }

            try { invHD = Convert.ToInt32(TBHDDVDs.Text); }
            catch (Exception) { invHD = -1; }

            // agregar valores a objeto género
            Géneros nGénero = new Géneros();
            nGénero.Nombre = genero;
            // agregar valores a objeto película
            Película nPelícula = new Película();
            nPelícula.Nombre = nombre;
            nPelícula.Género = -1;
            nPelícula.InvDVD = invDVD;
            nPelícula.InvBlueRay = invBR;
            nPelícula.InvHD = invHD;

            try { insRegistroBLL.RegistrarGéneroPelícula(nGénero, nPelícula); }
            catch (Exception ex)
            {
                div.InnerHtml = "<script > alert(' " + ex.Message + "');</script > ";
                return;
            }

            div.InnerHtml = "<script > alert(' Se ha registrado la película de forma exitosa');</script > ";

        }
    }
}