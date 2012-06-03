using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Alquilar : Form
    {
        public Alquilar()
        {
            InitializeComponent();
        }

        private void BAlquilar_Click(object sender, EventArgs e)
        {
            int cliente, película;
            // Chequeos
            if (int.TryParse(TBCódigoCliente.Text, out cliente) &&
                int.TryParse(TBCódigoPelícula.Text, out película))
            {
                Service1 service = new Service1();
                try
                {
                    service.RegistrarAlquiler(película, cliente);
                    MessageBox.Show("El alquiler se efectuó correctamente el pedido llega a su casa");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar alquiler?", "Cancelar", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
    }
}
