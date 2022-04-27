using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.RepositorioDados
{
    public static class DadosRepositorio
    {
        public readonly static ClienteDados ClienteDado = new ClienteDados();
        public readonly static FormaPagamentoDados FormaPagamentoDado = new FormaPagamentoDados();
        public readonly static PagamentoDados PagamentoDado =new PagamentoDados();
        public readonly static ProdutosDados ProdutosDado = new ProdutosDados();
    }
}