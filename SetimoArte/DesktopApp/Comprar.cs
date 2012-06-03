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
    public partial class Comprar : Form
    {
        public Comprar()
        {
            InitializeComponent();
        }

        private void BAlquilar_Click(object sender, EventArgs e)
        {
            int cliente, película;
            // Chequeos
            try { cliente = Convert.ToInt32(TBCódigoCliente.Text); }
            catch { cliente = -1; }

            try { película = Convert.ToInt32(TBCódigoPelícula.Text); }
            catch (Exception)
            {
                MessageBox.Show("Se debe seleccionar la película");
                return;
            }

            Service1 service = new Service1();
            try
            {
                service.RegistrarVenta(película, cliente);
                MessageBox.Show("La compra se ha registrado correctamente pronto entregaremos su pedido");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar alquiler?", "Cancelar", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
    }
}
