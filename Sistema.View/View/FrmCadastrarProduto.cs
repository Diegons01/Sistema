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
        private Produto _produto;

        public FrmCadastrarProduto()
        {
            InitializeComponent();
        }

        // Eventos
        private void FrmCadastrarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                carregaGridProduto();
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
                if (valida())
                {
                    if (_produto == null)
                    {
                        Produto produto = new Produto();

                        produto.Nome = this.txtNome.Text;
                        produto.Descricao = this.txtDescricao.Text;
                        produto.Quantidade = int.Parse(this.txtQuantidade.Text);
                        produto.Placa = this.txtPlaca.Text;
                        Cor cor = (Cor)this.cboCor.SelectedItem;
                        produto.CorId = cor.Id;
                        Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;
                        produto.CategoriaId = categoria.Id;

                        produto.Acessorio = (EnumAcessorio)this.cboAcessorio.SelectedItem;

                        produto.Preco = double.Parse(this.txtPreco.Text);
                        produto.Km = int.Parse(this.txtKm.Text);
                        produto.DataFabricacao = DateTime.Parse(this.dtDataFabricacao.Text);

                        ServiceProduto serviceProduto = new ServiceProduto();
                        serviceProduto.Create(produto);
                    }
                    else
                    {
                        ServiceProduto serviceProduto = new ServiceProduto();
                        Produto produto = serviceProduto.FindProtudo(_produto);

                        produto.Nome = this.txtNome.Text;
                        produto.Descricao = this.txtDescricao.Text;
                        produto.Quantidade = int.Parse(this.txtQuantidade.Text);
                        produto.Placa = this.txtPlaca.Text;
                        Cor cor = (Cor)this.cboCor.SelectedItem;
                        produto.CorId = cor.Id;
                        Categoria categoria = (Categoria)this.cboCategoria.SelectedItem;
                        produto.CategoriaId = categoria.Id;

                        produto.Acessorio = (EnumAcessorio)this.cboAcessorio.SelectedItem;

                        produto.Preco = double.Parse(this.txtPreco.Text);
                        produto.Km = int.Parse(this.txtKm.Text);
                        produto.DataFabricacao = DateTime.Parse(this.dtDataFabricacao.Text);

                        serviceProduto.Update();
                        _produto = null;
                    }

                    limparOsCamposTela();
                    carregaGridProduto();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparOsCamposTela();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.grvProduto.SelectedRows.Count > 0)
            {
                _produto = (Produto)this.grvProduto.CurrentRow.DataBoundItem;

                editar(_produto);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvProduto.SelectedRows.Count > 0)
                {
                    Produto produto = (Produto)this.grvProduto.CurrentRow.DataBoundItem;

                    ServiceProduto serviceProduto = new ServiceProduto();

                    serviceProduto.Delete(produto);
                    limparOsCamposTela();
                    carregaGridProduto();                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grvProduto.SelectedRows.Count > 0)
            {
                _produto = (Produto)this.grvProduto.CurrentRow.DataBoundItem;

                editar(_produto);                
            }
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

        private bool valida()
        {
            errorProviderTela.Clear();

            string msg = "Campo obrigatório!";

            //Nome
            if (string.IsNullOrWhiteSpace(this.txtNome.Text))
            {
                errorProviderTela.SetError(this.txtNome, msg);
                this.txtNome.Focus();
                return false;
            }
            //Descricao
            if (string.IsNullOrWhiteSpace(this.txtDescricao.Text))
            {
                errorProviderTela.SetError(this.txtDescricao, msg);
                this.txtDescricao.Focus();
                return false;
            }
            //Quantidade
            if (string.IsNullOrWhiteSpace(this.txtQuantidade.Text))
            {
                errorProviderTela.SetError(this.txtQuantidade, msg);
                this.txtQuantidade.Focus();
                return false;
            }
            //Placa
            if (string.IsNullOrWhiteSpace(this.txtPlaca.Text))
            {
                errorProviderTela.SetError(this.txtPlaca, msg);
                this.txtPlaca.Focus();
                return false;
            }
            //Cor
            if (this.cboCor.SelectedItem == null)
            {
                errorProviderTela.SetError(this.cboCor, msg);
                this.cboCor.Focus();
                return false;
            }
            //Categoria
            if (this.cboCategoria.SelectedItem == null)
            {
                errorProviderTela.SetError(this.cboCategoria, msg);
                this.cboCategoria.Focus();
                return false;
            }
            //Acessorio
            if (this.cboAcessorio.SelectedItem == null)
            {
                errorProviderTela.SetError(this.cboAcessorio, msg);
                this.cboAcessorio.Focus();
                return false;
            }
            //Preco
            if (string.IsNullOrWhiteSpace(this.txtPreco.Text))
            {
                errorProviderTela.SetError(this.txtPreco, msg);
                this.txtPreco.Focus();
                return false;
            }
            //Km
            if (string.IsNullOrWhiteSpace(this.txtKm.Text))
            {
                errorProviderTela.SetError(this.txtKm, msg);
                this.txtKm.Focus();
                return false;
            }
            //Fabricacao
            if (string.IsNullOrWhiteSpace(this.dtDataFabricacao.Text))
            {
                errorProviderTela.SetError(this.dtDataFabricacao, msg);
                this.dtDataFabricacao.Focus();
                return false;
            }

            return true;
        }

        private void limparOsCamposTela()
        {
            _produto = null;
            this.txtNome.Clear();
            this.txtDescricao.Clear();
            this.txtQuantidade.Clear();
            this.txtPlaca.Clear();
            this.txtPreco.Clear();
            this.txtKm.Clear();
            this.cboCor.SelectedItem = null;
            this.cboAcessorio.SelectedItem = null;
            this.cboCategoria.SelectedItem = null;
            this.dtDataFabricacao.Text = string.Empty;
        }

        private void carregaGridProduto()
        {
            ServiceProduto serviceProduto = new ServiceProduto();
            var list = serviceProduto.ListProdutos();
            this.grvProduto.DataSource = list;
        }

        private void editar(Produto produto)
        {
            this.txtNome.Text = produto.Nome;
            this.txtDescricao.Text = produto.Descricao;
            this.txtQuantidade.Text = produto.Quantidade.ToString();
            this.txtPlaca.Text = produto.Placa;
            this.cboCor.Text = produto.Cor.Nome;
            this.cboCategoria.Text = produto.Categoria.Nome;
            this.cboAcessorio.Text = produto.Acessorio.ToString();
            this.txtPreco.Text = produto.Preco.ToString();
            this.txtKm.Text = produto.Km.ToString();
            this.dtDataFabricacao.Text = produto.DataFabricacao.Date.ToString();
        }
       
    }
}
