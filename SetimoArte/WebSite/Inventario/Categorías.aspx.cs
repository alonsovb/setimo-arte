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
    public partial class Categorías : System.Web.UI.Page {
        Registros insRegistroBLL = new Registros();
        Consultas insConsultasBLL = new Consultas();

        protected void Page_Load(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            dt = insConsultasBLL.ConsultarGénero();
            GridLista.DataSource = dt;
            GridLista.DataBind();
        }

        protected void AgregarClicked(object sender, EventArgs e) {
            string nombre = TBNombre.Text;

            // agregar valores a objeto género
            Géneros nGénero = new Géneros();
            nGénero.Nombre = nombre;
            insRegistroBLL.RegistrarGénero(nGénero);
        }
    }
}