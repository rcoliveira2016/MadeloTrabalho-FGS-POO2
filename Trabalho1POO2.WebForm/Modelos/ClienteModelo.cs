using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class ClienteModelo : ModeloBase
    {        
        public long Codigo { 
            get { return Identificador; } 
            set { Identificador = value; } 
        }
        public string EnderecoCompleto
        {
            get { return $"{Complemento}, {Endereco}, {Cidade}, {Estado}"; }
        }
        public bool VerificarFormulario(out List<string> mensagens)
        {
            mensagens = new List<string>();

            RetornarMesagensErro(mensagens, CPF, "CPF");

            RetornarMesagensErro(mensagens, Nome, "Nome");

            RetornarMesagensErro(mensagens, Endereco, "Endereço");

            RetornarMesagensErro(mensagens, Complemento, "Complemento");

            RetornarMesagensErro(mensagens, Cep, "Cep");

            RetornarMesagensErro(mensagens, Cidade, "Cidade");

            RetornarMesagensErro(mensagens, Estado, "Estado");

            return mensagens.Count == 0;
        }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ClienteModelo(string cPF, string nome, string endereco, string complemento, string cep, string cidade, string estado)
        {
            CPF = cPF;
            Nome = nome;
            Endereco = endereco;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }
}