using Sistema.Controller.Service;
using Sistema.Model.Entities;
using System;
using System.Windows.Forms;

namespace Sistema.View.View
{
    public partial class FrmCor : Form
    {
        private Cor _cor;

        public FrmCor()
        {
            InitializeComponent();
        }

        public FrmCor(Cor cor) : this()
        {
            _cor = cor;
        }

        private void FrmCor_Load(object sender, EventArgs e)
        {
            try
            {
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
                    if (_cor == null)
                    {
                        Cor cor = new Cor //outro exemplo
                        {
                            Nome = this.txtNome.Text,
                            Descricao = this.txtDescricao.Text
                        };

                        ServiceCor serviceCor = new ServiceCor();
                        serviceCor.Create(cor);
                    }
                    else
                    {
                        ServiceCor serviceCor = new ServiceCor();

                        Cor cor = serviceCor.FindCor(_cor);

                        cor.Nome = this.txtNome.Text;
                        cor.Descricao = this.txtDescricao.Text;

                        serviceCor.Update();

                        _cor = null;
                    }

                    this.Close();
                }                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void preencheCampo()
        {
            this.txtNome.Text = _cor.Nome;
            this.txtDescricao.Text = _cor.Descricao;
        }

        private bool valida()
        {
            errorProviderTela.Clear();

            if (string.IsNullOrWhiteSpace(this.txtNome.Text))
            {
                errorProviderTela.SetError(this.txtNome, "Campo obrigatório!");
                this.txtNome.Focus();
                return false;
            }

            return true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cor != null)
                {
                    ServiceCor serviceCor = new ServiceCor();
                    serviceCor.Delete(_cor);
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
