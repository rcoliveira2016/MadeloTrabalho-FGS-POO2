using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm.RepositorioDados
{
    public class ClienteDados : DadosBase<ClienteModelo>
    {
        private readonly List<ClienteModelo> _data = new List<ClienteModelo>();
        protected override IList<ClienteModelo> Data => _data;
    }
}