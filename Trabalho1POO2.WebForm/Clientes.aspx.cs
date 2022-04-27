using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.Paginas
{
    public partial class Clientes : Page
    {
        public ClienteDados ClienteRepositorio = DadosRepositorio.ClienteDado;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }

        private void LimparCampos()
        {
            txtCep.Text =
                txtCidade.Text =
                txtComplemento.Text =
                txtCPF.Text =
                txtEndereco.Text =
                txtEstado.Text =
                txtNome.Text = string.Empty;
        }

        private void CarregarListagem()
        {
            grdDados.DataSource = ClienteRepositorio.BuscarTudo().ToList();
            grdDados.DataBind();
        }                

        protected void grdDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var codigo = Convert.ToInt64(e.Values[0]);
                ClienteRepositorio.Excluir(codigo);
                (Master as SiteMaster).AdicionarTextoSucesso("Cliente excluido com sucesso");
                CarregarListagem();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }

        protected void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var novoCliente = new ClienteModelo(txtCPF.Text, txtNome.Text, txtEndereco.Text, txtComplemento.Text, txtCep.Text, txtCidade.Text, txtEstado.Text);
                if (!novoCliente.VerificarFormulario(out var msg))
                {
                    (Master as SiteMaster).AdicionarTextoErro($"{msg.Aggregate((antes, depois) => antes + ", " + depois)}");
                    return;
                }
                ClienteRepositorio.Adicionar(novoCliente);
                LimparCampos();
                CarregarListagem();
                (Master as SiteMaster).AdicionarTextoSucesso("Cliente Cadastrado Com sucesso");
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro($"{exc.Message}");
            }
        }
    }
}