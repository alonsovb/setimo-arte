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
    public partial class RegistrarAlquileres : System.Web.UI.Page {
        Consultas insConsultasBLL = new Consultas();
        Registros insRegistroBLL = new Registros();
        static DataTable peliculas;
        static DataTable pelisAlquiladas = new DataTable();
        static bool crear = true;

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack)
            {
                int id_pelicula = -1;
                string nombre_pelicula = "";
                Película nPelícula = new Película();
                nPelícula.Id = id_pelicula;
                nPelícula.Nombre = nombre_pelicula;


                this.DPelícula.DataTextField = "nombre";
                this.DPelícula.DataValueField = "id_peliculas";
                peliculas = insConsultasBLL.ConsultarPelícula(nPelícula);
                this.DPelícula.DataSource = peliculas;
                this.DPelícula.DataBind();

                // creamos las columnas de la tabla de datos de "pelisAlquileres"
                if (crear)
                {
                    pelisAlquiladas.Columns.Add("idPelículas");
                    pelisAlquiladas.Columns.Add("cantDVD");
                    pelisAlquiladas.Columns.Add("cantBlueRay");
                    pelisAlquiladas.Columns.Add("cantHD");
                    crear = false;
                }
            }
        }

        protected void AgregarPelícula(object sender, EventArgs e) {
            string nPelícula = DPelícula.SelectedItem.ToString();
            int id = Convert.ToInt32(DPelícula.SelectedValue);

            DataTable Disponibilidad = insConsultasBLL.ConsultarDisponible(nPelícula, DFormato.SelectedItem.ToString());

            if (Disponibilidad.Rows.Count != 0)
            {
                insertarPelis(id, DFormato.SelectedValue.ToString());
                LBLista.Items.Add(nPelícula);
            }
            else
                div.InnerHtml = "<script > alert('No quedan películas disponibles');</script > ";
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            DateTime entrega;
            int plazo;
            int costo;
            int codigo_socio;

            fecha = DateTime.Now;
            
            try { codigo_socio = Convert.ToInt32(this.TBCliente.Text); }
            catch (Exception) { codigo_socio = -1; }


            Utilerías.Objetos.Cliente nCliente = new Utilerías.Objetos.Cliente();
            nCliente.NumeroSocio = codigo_socio;
            DataTable moroso = insConsultasBLL.ConsultarSocio(nCliente);
            
            if(moroso.Rows.Count != 0)
            {
                int estado = Convert.ToInt32(moroso.Rows[0]["estado"]);
                if (estado == 1)
                {
                    div.InnerHtml = "<script > alert('El usuario esta moroso');</script > ";
                }
                else 
                {
                    costo = calcCosto();
                    entrega = calcEntrega();
                    plazo = cantDias();

                    TBCosto.Text = costo.ToString();
                    TBDevolución.Text = entrega.ToString();

                    Alquiler nAlquiler = new Alquiler();
                    nAlquiler.Socio = codigo_socio;
                    nAlquiler.Fecha = fecha;
                    nAlquiler.Entrega = entrega;
                    nAlquiler.Costo = costo;
                    nAlquiler.Plazo = plazo;
                    nAlquiler.Devuelto = false;

                    try { insRegistroBLL.RegistrarAlquiler(nAlquiler, pelisAlquiladas); }
                    catch (Exception ex)
                    {
                        div.InnerHtml = "<script > alert(' " + ex.Message + "');</script > ";
                        return;
                    }
                    div.InnerHtml = "<script > alert('Se ha registrado el alquiler exitosamente');</script > ";
                }
                    
            }
            else
                div.InnerHtml = "<script > alert('No existe ningún socio asociado a ese código');</script > ";

            for(int i=0; i < pelisAlquiladas.Rows.Count; i++)
                   pelisAlquiladas.Rows.RemoveAt(i);
            
            }

        void insertarPelis(int id, string tipo)
        {
            int cant_dvd = 0;
            int cant_blueray = 0;
            int cant_hd = 0;

            if (tipo == "0")
                cant_dvd++;
            else if (tipo == "1")
                cant_blueray++;
            else
                cant_hd++;

            DataRow nRow = pelisAlquiladas.NewRow();
            nRow["idPelículas"] = id;
            nRow["cantDVD"] = cant_dvd;
            nRow["cantBlueRay"] = cant_blueray;
            nRow["cantHD"] = cant_hd;
            pelisAlquiladas.Rows.Add(nRow);

        }

        int cantDias()
        {
            if (pelisAlquiladas.Rows.Count < 2)
                return 1;
            else if (pelisAlquiladas.Rows.Count < 4)
                return 2;
            else if (pelisAlquiladas.Rows.Count > 3)
                return 3;
            else
                return -1;
        }

        int calcCosto()
        {
            int cantDVD = 0;
            int cantBR = 0;
            int cantHD = 0;
            int precio = 0;
            DataTable precios;
            precios = insConsultasBLL.ConsultarPrecioAlquiler();

            for(int i=0; i < pelisAlquiladas.Rows.Count; i++)
            {
                cantDVD = cantDVD + Convert.ToInt32(pelisAlquiladas.Rows[i]["cantDVD"]);
                cantBR = cantBR + Convert.ToInt32(pelisAlquiladas.Rows[i]["cantBlueRay"]);
                cantHD = cantHD + Convert.ToInt32(pelisAlquiladas.Rows[i]["cantHD"]);
            }

            //precios de DVD
            if (cantDVD < 4)
                precio = precio + (Convert.ToInt32(precios.Rows[0]["DVD"]) * cantDVD);
            else if(cantDVD == 4)
                precio = precio + Convert.ToInt32(precios.Rows[1]["DVD"]);
            else if (cantDVD > 4)
            {
                precio = precio + Convert.ToInt32(precios.Rows[1]["DVD"]) +
                         (cantDVD - 4) * Convert.ToInt32(precios.Rows[2]["DVD"]);
            }

            //precios de Blue Ray
            if (cantBR < 4)
                precio = precio + (Convert.ToInt32(precios.Rows[0]["BlueRay"]) * cantBR);
            if (cantBR == 4)
                precio = precio + Convert.ToInt32(precios.Rows[1]["BlueRay"]);
            if (cantBR > 4)
            {
                precio = precio + Convert.ToInt32(precios.Rows[1]["BlueRay"]) +
                         (cantBR - 4) * Convert.ToInt32(precios.Rows[2]["BlueRay"]);
            }

            //precios de HD DVD
            if (cantHD < 4)
                precio = precio + (Convert.ToInt32(precios.Rows[0]["HD"]) * cantHD);
            if (cantHD == 4)
                precio = precio + Convert.ToInt32(precios.Rows[1]["HD"]);
            if (cantHD > 4)
            {
                precio = precio + Convert.ToInt32(precios.Rows[1]["HD"]) +
                         (cantBR - 4) * Convert.ToInt32(precios.Rows[2]["HD"]);
            }

            return precio;
        }

        DateTime calcEntrega()
        {
            DataTable plazo = insConsultasBLL.ConsultarPlazo();
            int dias = cantDias();
            return DateTime.Now.AddDays(dias);            

        }

    }
}