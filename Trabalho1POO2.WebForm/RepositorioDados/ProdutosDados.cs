using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.RepositorioDados
{
    public class ProdutosDados : DadosBase<ProdutoModelo>
    {
        private readonly List<ProdutoModelo> _data = new List<ProdutoModelo>();
        protected override IList<ProdutoModelo> Data => _data;
    }
}