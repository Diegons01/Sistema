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
        private Categoria _categoria;

        public FrmCategoria()
        {
            InitializeComponent();
        }

        public FrmCategoria(Categoria categoria) : this()
        {
            try
            {
                _categoria = categoria;
                preencheCampo();
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
                if (valida())
                {
                    if (_categoria == null)
                    {
                        Categoria categoria = new Categoria();
                        categoria.Nome = this.txtCategoria.Text;

                        ServiceCategoria serviceCategoria = new ServiceCategoria();
                        serviceCategoria.Create(categoria);
                    }
                    else
                    {
                        ServiceCategoria serviceCategoria = new ServiceCategoria();
                        Categoria categoria = serviceCategoria.FindCategoria(_categoria.Id);

                        categoria.Nome = this.txtCategoria.Text;
                        serviceCategoria.update();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool valida()
        {
            this.errorProviderTela.Clear();

            if (string.IsNullOrEmpty(this.txtCategoria.Text))
            {
                this.errorProviderTela.SetError(this.txtCategoria, "Campo obrigatório!");
                return false;
            }

            return true;
        }

        private void preencheCampo()
        {
            this.txtCategoria.Text = _categoria.Nome.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoria != null)
                {
                    ServiceCategoria serviceCategoria = new ServiceCategoria();
                    serviceCategoria.Delete(_categoria);
                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
