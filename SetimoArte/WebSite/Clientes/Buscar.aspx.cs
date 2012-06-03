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
    public partial class BuscarClientes : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();
        DataTable cliente;

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BBuscar_Click(object sender, EventArgs e) {
            int código;
            try { código = Convert.ToInt32(TBCódigo.Text); } catch (Exception) { código = -1; }

            Utilerías.Objetos.Cliente nCliente = new Utilerías.Objetos.Cliente();
            nCliente.NumeroSocio = código;
            nCliente.Nombre = TBNombre.Text;

            cliente = insConsultasBLL.ConsultarSocio(nCliente);
            GVLista.DataSource = cliente;
            GVLista.DataBind();

            if (cliente.Rows[0].Field<byte[]>("fotografia") != null)
                IFotografía.ImageUrl = "/SocioFotografía.ashx?id=" + código.ToString();
            else
                IFotografía.ImageUrl = "/Avatar.png";
        }

    }
}