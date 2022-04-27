using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.RepositorioDados
{
    public class PagamentoDados : DadosBase<PagamentoModelo>
    {
        private readonly List<PagamentoModelo> _data = new List<PagamentoModelo>();
        protected override IList<PagamentoModelo> Data => _data;
    }
}