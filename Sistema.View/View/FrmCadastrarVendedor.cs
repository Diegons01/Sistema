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
        private ServiceVendedor _serviceVendedor;
        private Vendedor _vendedor;

        public FrmCadastrarVendedor()
        {
            InitializeComponent();
        }

        private void FrmCadastrarVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                bloqueiaCampos();
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
            using (FrmCategoria frm = new FrmCategoria())
            {
                frm.ShowDialog();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _vendedor = null;
            liberaCampos();
            limparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (valida())
                {
                    if (_vendedor == null)
                    {
                        _vendedor = new Vendedor();

                        _vendedor.Nome = this.txtNome.Text;
                        _vendedor.Email = this.txtEmail.Text;
                        _vendedor.Telefone = int.Parse(this.txtTelefone.Text);
                        _vendedor.Salario = double.Parse(this.txtSalario.Text);

                        Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;

                        // _vendedor.Id = categoria.Id;

                        _serviceVendedor = new ServiceVendedor();
                        _serviceVendedor.Create(_vendedor);

                        //new ServiceVendedor().Create(_vendedor);
                    }
                    else
                    {
                        _serviceVendedor = new ServiceVendedor();
                        Vendedor vendedor = _serviceVendedor.Find(_vendedor.Id);

                        vendedor.Nome = this.txtNome.Text;
                        vendedor.Email = this.txtEmail.Text;
                        vendedor.Telefone = int.Parse(this.txtTelefone.Text);
                        vendedor.Salario = double.Parse(this.txtSalario.Text);

                        _serviceVendedor.Update();
                    }

                    carregaGridVendedor();
                    limparCampos();

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

                    liberaCampos();
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
                _vendedor = (Vendedor)this.grvVendedor.CurrentRow.DataBoundItem;

                _serviceVendedor = new ServiceVendedor();

                _serviceVendedor.Delete(_vendedor);

                carregaGridVendedor();
            }
        }

        //Métodos      
        private void limparCampos()
        {
            this.txtNome.Clear();
            this.txtNome.Clear();
            this.txtEmail.Clear();
            this.txtEndereco.Clear();
            this.txtTelefone.Clear();
            this.txtSalario.Clear();
            this.cboCategoria.SelectedItem = null;
        }

        private void bloqueiaCampos()
        {
            this.txtNome.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtEndereco.Enabled = false;
            this.txtTelefone.Enabled = false;
            this.txtSalario.Enabled = false;
            this.cboCategoria.Enabled = false;
            this.btnNovoCategoria.Enabled = false;
            this.btnSalvar.Enabled = false;
        }

        private void liberaCampos()
        {
            this.txtNome.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtEndereco.Enabled = true;
            this.txtTelefone.Enabled = true;
            this.txtSalario.Enabled = true;
            this.cboCategoria.Enabled = true;
            this.btnNovoCategoria.Enabled = true;
            this.btnSalvar.Enabled = true;
        }

        private void editar(Vendedor vendedor)
        {
            this.txtNome.Text = vendedor.Nome;
            this.txtEmail.Text = vendedor.Email;
            //this.txtEndereco.Text =  vendedor.
            this.txtTelefone.Text = vendedor.Telefone.ToString();
            this.txtSalario.Text = vendedor.Salario.ToString();
        }

        private void carregaCombobox()
        {
            ServiceCategoria serviceCategoria = new ServiceCategoria();

            var obj = serviceCategoria.ListCategoria();

            this.cboCategoria.Items.Clear();

            foreach (Categoria item in obj)
            {
                this.cboCategoria.Items.Add(item);
            }
        }

        private void carregaGridVendedor()
        {
            ServiceVendedor serviceVendedor = new ServiceVendedor();

            this.grvVendedor.DataSource = serviceVendedor.ListVendedores();
        }

        private bool valida()
        {
            errorProviderTela.Clear();

            string mensagem = "Campo obrigatório!";

            if (string.IsNullOrEmpty(this.txtNome.Text))
            {
                errorProviderTela.SetError(this.txtNome, mensagem);
                this.txtNome.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(this.txtEndereco.Text))
            //{
            //    errorProviderTela.SetError(this.txtEndereco, mensagem);
            //    this.txtEndereco.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(this.txtTelefone.Text))
            {
                errorProviderTela.SetError(this.txtTelefone, mensagem);
                this.txtTelefone.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtSalario.Text))
            {
                errorProviderTela.SetError(this.txtSalario, mensagem);
                this.txtEmail.Focus();
                return false;
            }

            return true;
        }

        //Eventos
        private void grvVendedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvVendedor.SelectedRows.Count > 0)
                {
                    _vendedor = (Vendedor)this.grvVendedor.CurrentRow.DataBoundItem;

                    editar(_vendedor);
                    liberaCampos();
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
