using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model.Entities;
using Sistema.Controller.Service;


namespace Sistema.View.View
{
    public partial class FrmCadastrarVendedor : Form
    {
        public FrmCadastrarVendedor()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Vendedor vendedor = new Vendedor();

                vendedor.Nome = this.txtNome.Text;
                vendedor.Email = this.txtEmail.Text;
                vendedor.Telefone = int.Parse(this.txtTelefone.Text);
                vendedor.Salario = double.Parse(this.txtSalario.Text);

                new ServiceVendedor().SalvarVendedor(vendedor);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
