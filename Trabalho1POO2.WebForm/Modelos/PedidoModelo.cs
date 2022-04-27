using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TrabalhoModelo.WebForm.RepositorioDados;

namespace TrabalhoModelo.WebForm.Modelos
{
    public class PedidoModelo : ModeloBase
    {
        private List<ItemPedidoModelo> _itensPedidos;
        public void CalcularDataPrazo()
        {
            PrazoEntrega = DataEmissao.AddDays(20);
        }

        public void RemoverItem(long id)
        {
            var itemRemove = _itensPedidos.FirstOrDefault(x => x.Identificador == id);
            if (itemRemove != null)
                _itensPedidos.Remove(itemRemove);
        }

        public void AdiconarItem(ItemPedidoModelo item)
        {
            item.Identificador = _itensPedidos.Any() ? _itensPedidos.Max(x => x.Identificador) + 1 : 1;
            _itensPedidos.Add(item);
        }

        public bool VerificarFormulario(out List<string> mensagens)
        {
            mensagens = new List<string>();
            RetornarMesagensErro(mensagens, IdCliente, "Cliente");

            if (!ItensPedidos.Any())
                mensagens.Add("Adiconar pelo menos 1 produto");

            RetornarMesagensErro(mensagens, (long)Tipo, "Tipo de frete");


            return !mensagens.Any();
        }
        public double Total
        {
            get
            {
                return ItensPedidos.Sum(x => x.Total);
            }
        }

        public ClienteModelo Cliente
        {
            get
            {
                return DadosRepositorio.ClienteDado.BuscarPorId(IdCliente);
            }
        }

        public IList<ItemPedidoModelo> ItensPedidos
        {
            get
            {
                return _itensPedidos;
            }
        }

        public long IdCliente { get; set; }        
        public DateTime DataEmissao { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public eTipoFreteEntrega Tipo { get; set; }
        

        public PedidoModelo()
        {
            _itensPedidos = new List<ItemPedidoModelo>();
        }
    }

    public enum eTipoFreteEntrega
    {
        [Description("Transportadora")]
        Transportadora = 1,
        [Description("Correios")]
        Correios = 2,
        [Description("Aéreo")]
        Aereo = 3,
    }

    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}