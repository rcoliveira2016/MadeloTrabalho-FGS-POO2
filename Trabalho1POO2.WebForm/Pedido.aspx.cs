using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.Paginas
{
    public partial class Pedido : Page
    {
        public ClienteDados ClienteRepositorio = DadosRepositorio.ClienteDado;
        public ProdutosDados ProdutoRepositorio = DadosRepositorio.ProdutosDado;
        public FormaPagamentoDados FormaPagamentoRepositorio = DadosRepositorio.FormaPagamentoDado;
        public PagamentoDados PagamentoRepositorio = DadosRepositorio.PagamentoDado;

        public PagamentoModelo PagamentoModel
        {
            get
            {
                if (Session["PagamentoModel"] == null)
                {
                    Session["PagamentoModel"] = PagamentoModelo.Criar();
                }

                return (PagamentoModelo)Session["PagamentoModel"];
            }
            set { Session["PagamentoModel"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarItesnComponentes();
            }
            CarregarItensPedido();
        }

        private void CarregarItesnComponentes()
        {
            ddlCliente.Items.Clear();
            ddlCliente.Items.Add(new ListItem("", ""));
            foreach (var item in ClienteRepositorio.BuscarTudo())
            {
                ddlCliente.Items.Add(new ListItem(item.Nome, Convert.ToInt32(item.Identificador).ToString()));
            }

            ddlFormapagamento.Items.Clear();
            ddlFormapagamento.Items.Add(new ListItem("", ""));
            foreach (var item in FormaPagamentoRepositorio.BuscarTudo())
            {
                ddlFormapagamento.Items.Add(new ListItem(item.Descricao, Convert.ToInt32(item.Identificador).ToString()));
            }

            ddlProduto.Items.Clear();
            ddlProduto.Items.Add(new ListItem("", ""));
            foreach (var item in ProdutoRepositorio.BuscarTudo())
            {
                ddlProduto.Items.Add(new ListItem(item.Descricao, Convert.ToInt32(item.Identificador).ToString()));
            }

            CarregaritemFrete();
        }

        private void CarregaritemFrete()
        {
            var tiposFrete = Enum.GetValues(typeof(eTipoFreteEntrega)).Cast<eTipoFreteEntrega>().ToList();
            ddlTipoFrete.Items.Add(new ListItem("", ""));
            foreach (var item in tiposFrete)
            {
                ddlTipoFrete.Items.Add(new ListItem(item.GetEnumDescription(), Convert.ToInt32(item).ToString()));
            }
            ddlTipoFrete.DataBind();
        }


        private void LimparCamposAdicionarItemPedido()
        {
            ddlProduto.SelectedIndex = 0;
            txtQuantidadeitens.Text = null;
        }

        private void CarregarItensPedido()
        {
            grdItensPedido.DataSource = PagamentoModel.Pedido.ItensPedidos;
            grdItensPedido.DataBind();
        }


        public void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ddlCliente.Enabled = false;
                PagamentoModel.Pedido.IdCliente = Convert.ToInt64(ddlCliente.SelectedValue);
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }

        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                var itemPedido = new ItemPedidoModelo(Convert.ToInt64(txtQuantidadeitens.Text), Convert.ToInt64(ddlProduto.SelectedValue));
                PagamentoModel.Pedido.AdiconarItem(itemPedido);
                LimparCamposAdicionarItemPedido();
                CarregarItensPedido();
                (Master as SiteMaster).AdicionarTextoSucesso("Item Adicionado com sucesso");
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }

        protected void grdItensPedido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                PagamentoModel.Pedido.RemoverItem(Convert.ToInt64(e.Values[0]));
                (Master as SiteMaster).AdicionarTextoSucesso("Item remonvido com sucesso");
                CarregarItensPedido();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }

        protected void ddlFormapagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            PagamentoModel.FormaPagamento = FormaPagamentoRepositorio.BuscarPorId(Convert.ToInt64(ddlFormapagamento.SelectedValue));
            PagamentoModel.Pedido.CalcularDataPrazo();
        }

        public void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoModel.Pedido.Tipo = (eTipoFreteEntrega)Convert.ToInt64(ddlTipoFrete.SelectedValue);

                if (PagamentoModel.VerificarFormulario(out var mensagensErro))
                {
                    PagamentoModel.DataCompra = DateTime.Now;
                    PagamentoModel.Pedido.DataEmissao = DateTime.Now;
                    PagamentoRepositorio.Adicionar(PagamentoModel);
                    (Master as SiteMaster).AdicionarTextoSucesso("Comprado com sucesso");
                    cpnResumoPedido.Visible = true;
                    cpnResumoPedido.CarregarDados(PagamentoModel);
                    PagamentoModel = PagamentoModelo.Criar();
                }
                else
                {
                    (Master as SiteMaster).AdicionarTextoErro(mensagensErro.Aggregate((antes, depois) => antes + ", " + depois));
                }
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }

        }
    }
}