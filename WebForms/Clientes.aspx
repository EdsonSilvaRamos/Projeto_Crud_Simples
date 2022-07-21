<%@ Page Title="Lista de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebForm.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="principal">
        <div class="corrige-layout">
            <asp:HyperLink runat="server" class="btn btn-primary" NavigateUrl="~/CadastrarCliente.aspx">Novo Cliente</asp:HyperLink>
            <div class="tabela-clientes">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CssClass="table table-striped tamanho-gridview">
                    <Columns>

                        <asp:TemplateField HeaderText="Id" ItemStyle-Width="5px" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CPF" ItemStyle-Width="25px">
                            <ItemTemplate>
                                <asp:Label ID="lblCPF" runat="server" Text='<%# Eval("CPF") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nome" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RG" ItemStyle-Width="25px">
                            <ItemTemplate>
                                <asp:Label ID="lblRG" runat="server" Text='<%# Eval("RG") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25px"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" class="btn btn-success" NavigateUrl='<%# Eval("Id", "~/EditarCliente.aspx?Id={0}") %>'>Editar</asp:HyperLink>
                                | 
                    <asp:HyperLink runat="server" class="btn btn-info" NavigateUrl='<%# Eval("Id", "~/DetalhesCliente.aspx?Id={0}") %>'>Detalhes</asp:HyperLink>
                                | 
                    <asp:HyperLink runat="server" class="btn btn-danger" NavigateUrl='<%# Eval("Id", "~/ExcluirClientes.aspx?Id={0}") %>'>Excluir</asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="110px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
