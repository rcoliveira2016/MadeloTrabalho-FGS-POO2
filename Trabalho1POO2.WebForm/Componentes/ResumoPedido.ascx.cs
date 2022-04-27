using System;
using System.Web.UI;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.Componentes
{
    public partial class ResumoPedido : System.Web.UI.UserControl
    {
        public PagamentoDados PagamentoRepositorio = DadosRepositorio.PagamentoDado;

        private PagamentoModelo PagamentoModel
        {
            get
            {
                return (PagamentoModelo)Session["ResumoPedido"];
            }
            set { Session["ResumoPedido"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarCampos();
        }

        public void CarregarDados(PagamentoModelo pagamentoModel)
        {
            PagamentoModel = pagamentoModel;
            CarregarCampos();
        }
        private void CarregarCampos()
        {
            if (PagamentoModel == null) return;
            divPagamento.Visible = !PagamentoModel.EstaPago;
            CarregarItensPedido();

            spnDataCompra.InnerText = PagamentoModel.DataCompra.ToString();
            spnEnderecoEntrada.InnerText = PagamentoModel.Pedido.Cliente.EnderecoCompleto;

            spnEstaPago.InnerText = PagamentoModel.EstaPago ? "Sim" : "não";
            dtDataPagamento.Visible = ddDataPagamento.Visible = PagamentoModel.EstaPago;
            spnDataPagamento.InnerText = PagamentoModel.DataPagamento.ToString();

            spnFormaPagamento.InnerText = PagamentoModel.FormaPagamento.Descricao;
            spnFrete.InnerText = PagamentoModel.Pedido.Tipo.GetEnumDescription();
            spnNomeCliente.InnerText = PagamentoModel.Pedido.Cliente.Nome;
            spnNumero.InnerText = PagamentoModel.Identificador.ToString();
            spnPrevisaoEntrega.InnerText = PagamentoModel.DataPrazoEntrega.ToString();
            spnValorTotal.InnerText = PagamentoModel.TotalCompra.ToString();
        }
        private void CarregarItensPedido()
        {
            grdItensPedidoResumo.DataSource = PagamentoModel.Pedido.ItensPedidos;
            grdItensPedidoResumo.DataBind();
        }

        protected void btnConfrimaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoModel.PagamentoConfirmado();
                PagamentoRepositorio.Atualizar(PagamentoModel.Identificador, PagamentoModel);
                CarregarCampos();
                (Page.Master as SiteMaster).AdicionarTextoSucesso("Pago Com sucesso");
            }
            catch (Exception)
            {
                (Page.Master as SiteMaster).AdicionarTextoErro("Erro ao pagar");
            }
        }
    }
}