﻿<%@ Page Title="Clientes" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TrabalhoModelo.WebForm.Paginas.Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <h3>Listagem Clieste Cadastrados</h3>
    <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="true" OnRowDeleting="grdDados_RowDeleting"  >
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="Cep" HeaderText="Cep" />
            <asp:BoundField DataField="EnderecoCompleto" HeaderText="Endereço Completo" />

        </Columns>
    </asp:GridView>
    <hr/>
    <div>
        <div class="form-group">
            <label for="txtNome">Nome</label>
            <asp:TextBox  runat="server" ID="txtNome" />
        </div>
        <div class="form-group">
            <label for="txtCPF">CPF</label>
            <asp:TextBox  runat="server" ID="txtCPF" />
        </div>
        <div class="form-group">
            <label for="txtCep">Cep</label>
            <asp:TextBox  runat="server" ID="txtCep" />
        </div>
        <div>
            <div class="form-group">
                <label for="txtComplemento">Complemento</label>
                <asp:TextBox  runat="server" ID="txtComplemento" />
            </div>
        </div>
        <div>
            <div class="form-group">
                <label for="txtEndereco">Endereço</label>
                <asp:TextBox  runat="server" ID="txtEndereco" />
            </div>
        </div>
        <div>
            <div class="form-group">
                <label for="txtCidade">Cidade</label>
                <asp:TextBox  runat="server" ID="txtCidade" />
            </div>
        </div>
        <div>
            <div class="form-group">
                <label for="txtEstado">Estado</label>
                <asp:TextBox  runat="server" ID="txtEstado" />
            </div>
        </div>
        <asp:Button runat="server" Text="Cadastrar" ID="btnCadastrarCliente" OnClick="btnCadastrarCliente_Click" />
    </div>
    <hr/>
    
</asp:Content>
