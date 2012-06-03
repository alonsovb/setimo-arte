using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Utilerías.Objetos;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WebSite {
    /// <summary>
    /// Obtiene los datos de interfaz
    /// Creada por Kenneth Sancho y Alonso Vega
    /// Estudiantes de Ing. Computacion
    /// Telefono: 87557833 y 85540554
    /// Email: kennethsancho@gmail.com
    ///        
    /// </summary>
    public partial class RegistrarClientes : System.Web.UI.Page {
        Registros registroBLL = new Registros();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            string nombre;
            string apellidos;
            int telefono;
            string email;
            string direccion;
            DateTime afiliacion;
            int estado;

            if (!FUFotografía.HasFile) return;

            try { telefono = Convert.ToInt32(TBTeléfono.Text); }
            catch (Exception) { telefono = -1; }

            nombre = TBNombre.Text;
            apellidos = TBApellidos.Text;
            Utilerías.Objetos.Cliente NSocio = new Utilerías.Objetos.Cliente();
            try {
                if (FUFotografía.PostedFile != null &&
                    FUFotografía.PostedFile.FileName != "") {
                    byte[] imageSize = FUFotografía.FileBytes;
                    NSocio.Fotografía = imageSize;
                }
            } catch (Exception) {
                return;
            }
            
            email = TBEmail.Text;
            direccion = TBDirección.Text;
            afiliacion = DateTime.Now;
            estado = 1;

            NSocio.Nombre = nombre;
            NSocio.Apellidos = apellidos;
            
            NSocio.Teléfono = telefono;
            NSocio.Email = email;
            NSocio.Dirección = direccion;
            NSocio.Afiliación = afiliacion;
            NSocio.Estado = estado;
            try { registroBLL.RegistrarSocio(NSocio); }
            catch (Exception ex)
            {
                div.InnerHtml = "<script > alert(' " + ex.Message + "');</script > ";
                return;
            }

            div.InnerHtml = "<script > alert(' Se ha registrado el cliente de forma exitosa');</script > ";
            
        }

        
    }
}