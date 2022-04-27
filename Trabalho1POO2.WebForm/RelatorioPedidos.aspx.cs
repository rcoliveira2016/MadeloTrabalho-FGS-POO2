using System;
using System.Web.UI;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.Paginas
{
    public partial class RelatorioPedidos : Page
    {
        public PagamentoDados PagamentoRepositorio = DadosRepositorio.PagamentoDado;
        public PagamentoModelo PagamentoModel
        {
            get
            {
                return (PagamentoModelo)Session["PagamentoModelo"];
            }
            set { Session["PagamentoModelo"] = value; }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                cpnResumoPedido.Visible = false;
                long numeroPedido = Convert.ToInt64(txtNumeroPedido.Text);
                var pagamento = PagamentoRepositorio.BuscarPorId(numeroPedido);
                if (pagamento == null)
                {
                    (Master as SiteMaster).AdicionarTextoErro($"O pedido '{numeroPedido}' não foi encontrado");
                    return;
                }

                PagamentoModel = pagamento;
                cpnResumoPedido.Visible = true;
                cpnResumoPedido.CarregarDados(PagamentoModel);
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }
    }
}