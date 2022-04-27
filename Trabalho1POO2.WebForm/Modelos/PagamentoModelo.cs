using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class PagamentoModelo: ModeloBase
    {
        public DateTime DataPrazoEntrega
        {
            get
            {
                return Pedido?.PrazoEntrega ?? DateTime.MinValue;
            }
        }

        public FormaPagamentoModelo FormaPagamento { get; set; }
        public double TotalCompra
        {
            get
            {
                return CalcularValorCompra();
            }
        }

        private double CalcularValorCompra()
        {
            if (Pedido == null) return 0;
            if (FormaPagamento == null) return Pedido.Total;

            var desconto = Pedido.Total * (FormaPagamento.Desconto / 100);
            return Pedido.Total - desconto;
        }

        public bool VerificarFormulario(out List<string> mensagens)
        {
            Pedido.VerificarFormulario(out mensagens);


            if (TotalCompra < 50)
            {
                mensagens.Add("Não permitir valor total do pedido menor que 50 reais");
            }
            if (TotalCompra > 2000)
            {
                mensagens.Add("Valor máximo para forma de pagamento cartão de crédito é R$ 2.000, 00(dois mil reais)");
            }

            RetornarMesagensErro(mensagens, FormaPagamento, "Forma de pagamento");

            return mensagens.Count == 0;
        }

        public void PagamentoConfirmado()
        {
            DataPagamento = DateTime.Now;
            EstaPago = true;
        }
        public long IdPedido { get; set; }
        public PedidoModelo Pedido { get; set; }
        public DateTime DataCompra { get; set; }
        public bool EstaPago { get; set; }
        public DateTime DataPagamento { get; set; }
        
        public PagamentoModelo()
        {

        }

        public static PagamentoModelo Criar()
        {
            return new PagamentoModelo()
            {
                Pedido = new PedidoModelo() { DataEmissao = DateTime.Now },
                DataCompra = DateTime.Now,
            };
        }

    }
}