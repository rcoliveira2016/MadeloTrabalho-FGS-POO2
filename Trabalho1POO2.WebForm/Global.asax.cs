using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using TrabalhoModelo.WebForm.RepositorioDados;
using TrabalhoModelo.WebForm.Modelos;

namespace TrabalhoModelo.WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var produtos = DadosRepositorio.ProdutosDado;
            var formaspAgamento = DadosRepositorio.FormaPagamentoDado;
            var clientes = DadosRepositorio.ClienteDado;

            produtos.Adicionar(new ProdutoModelo("Produto 1", 3.50));
            produtos.Adicionar(new ProdutoModelo("Produto 2", 1.1));
            produtos.Adicionar(new ProdutoModelo("Produto 3", 15));
            produtos.Adicionar(new ProdutoModelo("Produto 4", 5.99));
            produtos.Adicionar(new ProdutoModelo("Produto 5", 1.99));

            formaspAgamento.Adicionar(new FormaPagamentoModelo("Cartão de Crédito", 0));
            formaspAgamento.Adicionar(new FormaPagamentoModelo("Cartão de Débito", 1));
            formaspAgamento.Adicionar(new FormaPagamentoModelo("Boleto Bancário", 3));
            formaspAgamento.Adicionar(new FormaPagamentoModelo("Pay Pal", 4));
            formaspAgamento.Adicionar(new FormaPagamentoModelo("Depósito em Conta", 5));

            clientes.Adicionar(new ClienteModelo("111111111", "c 1", "Rua 1", "comp 5", "111111", "caxias do sul", "RS"));
            clientes.Adicionar(new ClienteModelo("222222222", "c 2", "Rua 1", "comp 4", "22222", "caxias do sul", "RS"));
            clientes.Adicionar(new ClienteModelo("333333333", "c 3", "Rua 1", "comp 3", "33333", "caxias do sul", "RS"));
            clientes.Adicionar(new ClienteModelo("444444444", "c 4", "Rua 1", "comp 4", "444444", "caxias do sul", "RS"));
        }

    }
}