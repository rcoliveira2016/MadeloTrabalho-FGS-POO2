using System;
using System.Linq;
using System.Web.UI.WebControls;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.Paginas
{
    public partial class Produtos : System.Web.UI.Page
    {
        public ProdutosDados ProdutoRepositorio = DadosRepositorio.ProdutosDado;
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }
        public void LimparCampos()
        {
            txtDescricao.Text = "";
            txtPreco.Text = "0";
        }

        private void CarregarListagem()
        {
            grdDados.DataSource = ProdutoRepositorio.BuscarTudo().ToList();
            grdDados.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var produto = new ProdutoModelo(txtDescricao.Text, Convert.ToInt64(txtPreco.Text));
            if (produto.VerificarFormulario(out var mgs))
            {
                (Master as SiteMaster).AdicionarTextoSucesso("Comprado com sucesso");
                ProdutoRepositorio.Adicionar(produto);
                LimparCampos();
                CarregarListagem();
            }
            else
            {
                (Master as SiteMaster).AdicionarTextoErro(mgs.Aggregate((antes, depois) => antes+", "+depois));
            }

        }

        protected void grdDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var codigo = Convert.ToInt64(e.Values[0]);
                ProdutoRepositorio.Excluir(codigo);
                (Master as SiteMaster).AdicionarTextoSucesso("Produto excluido com sucesso");
                CarregarListagem();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }
    }
}