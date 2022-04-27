using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class FormaPagamentoModelo : ModeloBase
    {        
        public long Codigo {
            get { return Identificador; }
            set { Identificador = value; } 
        }
        public string Descricao { get; set; }
        public double Desconto { get; set; }
        public FormaPagamentoModelo(string descricao, double desconto)
        {
            Descricao = descricao;
            Desconto = desconto;
        }

    }
}