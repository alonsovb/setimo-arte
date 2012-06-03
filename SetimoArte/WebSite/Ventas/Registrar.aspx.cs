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
    public partial class RegistrarVentas : System.Web.UI.Page
    {
        Consultas insConsultasBLL = new Consultas();
        Registros insRegistroBLL = new Registros();
        static DataTable peliculas;
        static DataTable pelisVendidas = new DataTable();
        static bool crear = true;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Película nPelícula = new Película();
                nPelícula.Id = -1;
                nPelícula.Nombre = "";


                this.DPelícula.DataTextField = "nombre";
                this.DPelícula.DataValueField = "id_peliculas";
                peliculas = insConsultasBLL.ConsultarPelícula(nPelícula);
                this.DPelícula.DataSource = peliculas;
                this.DPelícula.DataBind();

                // creamos las columnas de la tabla de datos de "pelisAlquileres"
                if (crear)
                {
                    pelisVendidas.Columns.Add("idPelículas");
                    crear = false;
                }
            }
        }

        protected void AgregarPelícula(object sender, EventArgs e)
        {
            string nPelícula = DPelícula.SelectedItem.ToString();
            int id = Convert.ToInt32(DPelícula.SelectedValue);

            DataTable Disponibilidad = insConsultasBLL.ConsultarDisponible(nPelícula, "DVD");

            if (Disponibilidad.Rows.Count != 0)
            {
                DataRow nRow = pelisVendidas.NewRow();
                nRow["idPelículas"] = id;
                pelisVendidas.Rows.Add(nRow);

                LBLista.Items.Add(nPelícula);
            }
            else
                div.InnerHtml = "<script > alert('No quedan peliculas disponibles');</script > ";

           
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            DataTable esSocio;
            int codigo_socio;
            DateTime fecha;
            int costo = 0;

            try { codigo_socio = Convert.ToInt32(TBCliente.Text); }
            catch (Exception) { codigo_socio = -1; }

            fecha = DateTime.Now;

            if (codigo_socio != -1)
            {
                Utilerías.Objetos.Cliente nCliente = new Utilerías.Objetos.Cliente();
                nCliente.NumeroSocio = codigo_socio;
                esSocio = insConsultasBLL.ConsultarSocio(nCliente);
            
                if (esSocio.Rows.Count != 0)
                {
                    costo = calcCosto("socio");
                }
            }

            else
            {
                costo = calcCosto("particular");
            }

            TBCosto.Text = costo.ToString();

            Venta nVenta = new Venta();
            nVenta.Cliente = codigo_socio;
            nVenta.Fecha = fecha;
            nVenta.Costo = costo;

            try { insRegistroBLL.RegistrarVenta(nVenta, pelisVendidas); }
            catch (Exception ex)
            {
                div.InnerHtml = "<script > alert(' " + ex.Message + "');</script > ";
                return;
            }

            div.InnerHtml = "<script > alert('Se registro la venta de forma exitosa');</script > ";

            for (int i = 0; i < pelisVendidas.Rows.Count; i++)
                pelisVendidas.Rows.RemoveAt(i);
        }

        int calcCosto(string comprador)
        {
            int precio = 0;
            DataTable precios;
            precios = insConsultasBLL.ConsultarPrecioVenta();

            if (comprador == "socio")
            {
                int cantPelícula = pelisVendidas.Rows.Count;
                precio = cantPelícula * Convert.ToInt32(precios.Rows[0]["precio"]);
            }
            else
            {
                int cantPelícula = pelisVendidas.Rows.Count;
                precio = cantPelícula * Convert.ToInt32(precios.Rows[1]["precio"]);
            }

            return precio;
        }

    }
}