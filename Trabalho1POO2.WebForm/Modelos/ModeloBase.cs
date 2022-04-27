using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoModelo.WebForm.Modelos
{
    public abstract class ModeloBase
    {
        public long Identificador { get; set; }

        public void RetornarMesagensErro(List<string> msg, string valorCampo, string nomeCampo)
        {
            if (string.IsNullOrEmpty(valorCampo))
            {
                msg.Add($"Campo {nomeCampo} está vazio");
            }                
        }

        public void RetornarMesagensErro(List<string> msg, long valorCampo, string nomeCampo)
        {
            if (valorCampo == 0)
            {
                msg.Add($"Campo {nomeCampo} está vazio");
            }
        }

        public void RetornarMesagensErro(List<string> msg, object valorCampo, string nomeCampo)
        {
            if (valorCampo == null)
            {
                msg.Add($"Campo {nomeCampo} está vazio");
            }
        }

    }
}