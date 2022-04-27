using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class ProdutoModelo : ModeloBase
    {
        public bool VerificarFormulario(out List<string> mensagens)
        {
            mensagens = new List<string>();

            RetornarMesagensErro(mensagens, PrecoVenda, "Preço");

            RetornarMesagensErro(mensagens, Descricao, "Descrição");


            return mensagens.Count == 0;
        }
        public string Descricao { get; set; }
        public double PrecoVenda { get; set; }
        public ProdutoModelo(string descricao, double precoVenda)
        {
            Descricao = descricao;
            PrecoVenda = precoVenda;
        }        
    }
}