using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Service1 insConsultar = new Service1();
            DataTable películas = new DataTable();
            películas = insConsultar.ConsultarPelículas(-1, "");
            GVPelículas.DataSource = películas;
        }

        private void BRegistrarAlquiler_Click(object sender, EventArgs e)
        {
            Alquilar alq = new Alquilar();
            alq.ShowDialog(this);
        }

        private void BRegistrarVenta_Click(object sender, EventArgs e)
        {
            Comprar comp = new Comprar();
            comp.ShowDialog(this);
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            int código;
            string nombre;

            try { código = Convert.ToInt32(TBCódigo.Text); }
            catch (Exception) { código = -1; }

            nombre = TBNombre.Text;

            Service1 insConsultar = new Service1();
            DataTable películas = new DataTable();
            películas = insConsultar.ConsultarPelículas(código, nombre);
            GVPelículas.DataSource = películas;
        }

        

       
    }
}
