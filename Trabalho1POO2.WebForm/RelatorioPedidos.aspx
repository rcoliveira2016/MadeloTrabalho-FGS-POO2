<%@ Page Title="Relatorio pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RelatorioPedidos.aspx.cs" Inherits="TrabalhoModelo.WebForm.Paginas.RelatorioPedidos" %>
<%@ Register Src="~/Componentes/ResumoPedido.ascx" TagPrefix="comp" TagName="ResumoPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr/>
    <div>
        <div class="form-group">
            <label for="txtNumeroPedido">Numero Pedido:</label>
            <asp:TextBox  runat="server" ID="txtNumeroPedido" TextMode="Number" />
        </div>
    </div>
    <div>
        <div class="form-group">
            <asp:Button  runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" Text="Pesquisar" />
        </div>
    </div>
    <comp:ResumoPedido runat="server" ID="cpnResumoPedido" Visible="false"></comp:ResumoPedido>    
</asp:Content>
