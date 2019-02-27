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
using Sistema.Model.Entities.Enums;

namespace Sistema.View.View
{
    public partial class FrmCadastrarProduto : Form
    {
        public FrmCadastrarProduto()
        {
            InitializeComponent();
        }

        // Eventos
        private void FrmCadastrarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                carregaComboBox();
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        //Métodos
        private void carregaComboBox()
        {
            ServiceCor serviceCor = new ServiceCor();

            this.cboCor.DataSource = serviceCor.ListCor();
            this.cboCor.SelectedIndex += -1;

            ServiceCategoria serviceCategoria = new ServiceCategoria();

            this.cboCategoria.DataSource = serviceCategoria.ListCategoria();
            this.cboCategoria.SelectedIndex += -1;

            this.cboAcessorio.DataSource = Enum.GetValues(typeof(EnumAcessorio));
            this.cboAcessorio.SelectedIndex += -1;
        }
    }
}
