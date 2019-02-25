using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dados.EntityFramework;
using Sistema.Model.Entities;
using Sistema.Controller.Service;

namespace Sistema.View.View
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();

                categoria.Nome = this.txtCategoria.Text;

                ServiceCategoria serviceCategoria = new ServiceCategoria();

                serviceCategoria.Create(categoria);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
