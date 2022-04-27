using System;
using System.Web.UI;

namespace TrabalhoModelo.WebForm
{
    public partial class SiteMaster : MasterPage
    {
        private string _textoErro;
        public string textoErro
        {
            get
            {
                divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
                divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
                return _textoErro;
            }
        }

        private string _textoSucesso;
        public string textoSucesso
        {
            get
            {
                divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
                divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
                return _textoSucesso;
            }
        }

        public void AdicionarTextoErro(string texto)
        {
            _textoErro = texto;
            divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
            divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
        }

        public void AdicionarTextoSucesso(string texto)
        {
            _textoSucesso = texto;
            divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
            divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
            divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
        }
    }
}