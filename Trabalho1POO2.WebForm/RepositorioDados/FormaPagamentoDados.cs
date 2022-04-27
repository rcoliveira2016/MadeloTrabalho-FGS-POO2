using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.RepositorioDados
{
    public class FormaPagamentoDados : DadosBase<FormaPagamentoModelo>
    {
        private readonly List<FormaPagamentoModelo> _data = new List<FormaPagamentoModelo>();
        protected override IList<FormaPagamentoModelo> Data => _data;
    }
}