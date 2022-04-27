using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoModelo.WebForm.RepositorioDados;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class ItemPedidoModelo : ModeloBase
    {
        
        public void SetarCalculo()
        {
            Total = Quantidade * ValorUnitario;
        }

        public ProdutoModelo Produto
        {
            get
            {
                return DadosRepositorio.ProdutosDado.BuscarPorId(IdProdudo);
            }
        }

        public long NumeroProduto
        {
            get
            {
                return Identificador;
            }
        }

        public double ValorUnitario
        {
            get
            {
                return Produto?.PrecoVenda ?? 0;
            }
        }

        public string Descricao
        {
            get
            {
                return Produto?.Descricao;
            }
        }

        public long Quantidade { get; private set; }
        public long IdProdudo { get; private set; }
        public double Total { get; set; }

        public ItemPedidoModelo(long quantidade, long idProdudo)
        {
            Quantidade = quantidade;
            IdProdudo = idProdudo;
            SetarCalculo();
        }
    }
}