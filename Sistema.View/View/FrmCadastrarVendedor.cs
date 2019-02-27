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
        private Vendedor _vendedor;

        public FrmCadastrarVendedor()
        {
            InitializeComponent();
        }
        
        //Eventos  
        private void FrmCadastrarVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                carregaGridVendedor();
                carregaCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoCategoria_Click(object sender, EventArgs e)
        {
            if (this.cboCategoria.SelectedItem == null)
            {
                using (FrmCategoria frm = new FrmCategoria())
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;

                using (FrmCategoria frm = new FrmCategoria(categoria))
                {
                    frm.ShowDialog();
                }
            }
            carregaCombobox();
            carregaGridVendedor();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparOsCamposTela();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (valida())
                {
                    if (_vendedor == null)
                    {
                        Vendedor vendedor = new Vendedor();

                        vendedor.Nome = this.txtNome.Text;
                        vendedor.Email = this.txtEmail.Text;
                        vendedor.Cidade = this.txtCidade.Text;
                        vendedor.Telefone = int.Parse(this.txtTelefone.Text);
                        vendedor.Salario = double.Parse(this.txtSalario.Text);
                        vendedor.Estado = this.txtEstado.Text;
                        vendedor.DataNascimento = DateTime.Parse(this.dtDataNascimento.Text);

                        Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;

                        vendedor.CategoriaId = categoria.Id;

                        ServiceVendedor serviceVendedor = new ServiceVendedor();
                        serviceVendedor.Create(vendedor);
                    }
                    else
                    {
                        ServiceVendedor serviceVendedor = new ServiceVendedor();
                        Vendedor vendedor = serviceVendedor.Find(_vendedor.Id);

                        vendedor.Nome = this.txtNome.Text;
                        vendedor.Email = (this.txtEmail.Text != null) ? this.txtEmail.Text : "null@.com";
                        vendedor.Cidade = this.txtCidade.Text;
                        vendedor.Telefone = int.Parse(this.txtTelefone.Text);
                        vendedor.Salario = double.Parse(this.txtSalario.Text);
                        vendedor.Estado = this.txtEstado.Text;
                        vendedor.DataNascimento = DateTime.Parse(this.dtDataNascimento.Text);

                        Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;
                        vendedor.CategoriaId = categoria.Id;

                        serviceVendedor.Update();
                        _vendedor = null;
                    }

                    carregaGridVendedor();
                    LimparOsCamposTela();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvVendedor.SelectedRows.Count > 0)
                {
                    _vendedor = (Vendedor)this.grvVendedor.CurrentRow.DataBoundItem;

                    editar(_vendedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao editar! \n" + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.grvVendedor.SelectedRows.Count > 0)
            {
                Vendedor vendedor = (Vendedor)this.grvVendedor.CurrentRow.DataBoundItem;

                ServiceVendedor serviceVendedor = new ServiceVendedor();

                serviceVendedor.Delete(vendedor);
                LimparOsCamposTela();
                carregaGridVendedor();
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCategoria.SelectedItem == null)
            {
                this.btnNovoCategoria.Image = Properties.Resources.Novo1;
            }
            else
            {
                this.btnNovoCategoria.Image = Properties.Resources.Alterar;
            }
        }

        private void grvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvVendedor.SelectedRows.Count > 0)
                {
                    _vendedor = (Vendedor)this.grvVendedor.CurrentRow.DataBoundItem;

                    editar(_vendedor);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Métodos      
        private void LimparOsCamposTela()
        {
            _vendedor = null;
            this.txtNome.Clear();
            this.txtNome.Clear();
            this.txtEmail.Clear();
            this.txtCidade.Clear();
            this.txtTelefone.Clear();
            this.txtSalario.Clear();
            this.cboCategoria.SelectedItem = null;
            this.txtEstado.Clear();
        }

        private void editar(Vendedor vendedor)
        {
            this.txtNome.Text = vendedor.Nome;
            this.txtEmail.Text = vendedor.Email;
            this.txtCidade.Text = vendedor.Cidade;
            this.txtTelefone.Text = vendedor.Telefone.ToString();
            this.txtSalario.Text = vendedor.Salario.ToString("F2");
            this.txtEstado.Text = vendedor.Estado;
            this.dtDataNascimento.Text = vendedor.DataNascimento.ToString();
            this.cboCategoria.Text = vendedor.Categoria.Nome;
        }

        private void carregaCombobox()
        {
            ServiceCategoria serviceCategoria = new ServiceCategoria();

            this.cboCategoria.DataSource = serviceCategoria.ListCategoria();
            this.cboCategoria.SelectedIndex += -1;
        }

        private void carregaGridVendedor()
        {
            ServiceVendedor serviceVendedor = new ServiceVendedor();
            var obj = serviceVendedor.ListVendedores();
            this.grvVendedor.DataSource = obj;
        }

        //Falta implementar mais validações
        private bool valida()
        {
            errorProviderTela.Clear();

            string mensagem = "Campo obrigatório!";

            if (string.IsNullOrEmpty(this.txtNome.Text))
            {
                errorProviderTela.SetError(this.txtNome, mensagem);
                this.txtNome.Focus();
                return false;
            } //Nome
            if (string.IsNullOrEmpty(this.txtCidade.Text))
            {
                errorProviderTela.SetError(this.txtCidade, mensagem);
                this.txtCidade.Focus();
                return false;
            }//Cidade
            if (string.IsNullOrEmpty(this.txtEstado.Text))
            {
                errorProviderTela.SetError(this.txtEstado, mensagem);
                this.txtEstado.Focus();
                return false;
            }//Estado
            if (string.IsNullOrEmpty(this.txtTelefone.Text))
            {
                errorProviderTela.SetError(this.txtTelefone, mensagem);
                this.txtTelefone.Focus();
                return false;
            }//Telefone
            if (string.IsNullOrEmpty(this.txtSalario.Text))
            {
                errorProviderTela.SetError(this.txtSalario, mensagem);
                this.txtEmail.Focus();
                return false;
            }//Salario
            if (this.cboCategoria.SelectedItem == null)
            {
                errorProviderTela.SetError(this.cboCategoria, mensagem);
                this.cboCategoria.Focus();
                return false;
            } //Categoria

            return true;
        }                      
    }
}
