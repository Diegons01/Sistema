using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.View.View
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnCadastrarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCadastrarVendedor frm = new FrmCadastrarVendedor())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro desconhecido" + ex.Message);
            }
        }

        private void Relogio_Tick(object sender, EventArgs e)
        {
            try
            {
                this.toolStripHora.Text = DateTime.Now.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCadastrarProduto frm = new FrmCadastrarProduto())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro desconhecido" + ex.Message);
            }
        }
    }
}
