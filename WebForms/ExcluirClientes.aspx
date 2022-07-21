<%@ Page Title="Excluir Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcluirClientes.aspx.cs" Inherits="WebForm.ExcluirClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="principal">

        <div class="corrige-layout-telas">

            <h2>Deseja realmente excluir esse cliente?</h2>

            <div class="form-horizontal">

                <hr />

                 <dl class="dl-horizontal">

                    <dt>
                        <label>Nome</label>
                    </dt>

                    <dd>
                        <asp:Label ID="LabelNome" runat="server"></asp:Label>
                    </dd>

                    <dt>
                        <label>CPF</label>
                    </dt>

                    <dd>
                        <asp:Label ID="LabelCPF" runat="server"></asp:Label>
                    </dd>

                    <dt>
                        <label>RG</label>
                    </dt>

                    <dd>
                        <asp:Label ID="LabelRG" runat="server"></asp:Label>
                    </dd>

                </dl>

                <div class="container-inputs links-acao">
                    <div>
                        <asp:HyperLink runat="server" class="btn btn-primary" NavigateUrl="~/Clientes.aspx">← Voltar</asp:HyperLink>
                    </div>
                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Excluir" CssClass="retira-transform-text tamanho-links-acao btn btn-danger" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
