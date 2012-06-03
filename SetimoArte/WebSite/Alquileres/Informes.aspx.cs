using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Utilerías.Objetos;
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
    public partial class InformesAlquileres : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            DateTime entrega;
            int codigoSocio;

            try { codigoSocio = Convert.ToInt32(TBSocio.Text); }
            catch (Exception) { codigoSocio = -1; }

            fecha = CInicio.SelectedDate;
            entrega = CFinal.SelectedDate;

            Alquiler nAlquileres = new Alquiler();
            nAlquileres.Fecha = fecha;
            nAlquileres.Entrega = entrega;
            DataTable InfoAlquileres = insConsultasBLL.ConsultarAlquilerFecha(nAlquileres,codigoSocio);
            this.GVLista.DataSource = InfoAlquileres;
            this.GVLista.DataBind();

        }
    }
}