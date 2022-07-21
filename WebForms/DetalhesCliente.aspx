<%@ Page Title="Detalhes Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalhesCliente.aspx.cs" Inherits="WebForm.DetalhesCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="principal">

        <div class="corrige-layout-telas">

            <h2>Detalhes Cliente</h2>

            <div class="form-horizontal">

                <hr />

                <span class="fildset-cliente">Cliente</span>

                <asp:Label ID="lblId" runat="server" Visible="false" ></asp:Label>

                <div class="container-inputs">
                    <div class="col-lg-2">
                        <asp:Label ID="LabelCPF" runat="server" Text="CPF" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxCPF" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>                        
                    </div>

                    <div class="col-lg-12">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>                        
                    </div>
                </div>

                <div class="container-inputs">
                    <div class="col-lg-3">
                        <asp:Label ID="LabelRG" runat="server" Text="RG" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxRG" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>                        
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelDataExpedicao" runat="server" Text="Data Expedição" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxDataExpedicao" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>                        
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelOrgaoExpedicao" runat="server" Text="Orgao Espedição" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListOrgaoExpedicao" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelUfExpedicao" runat="server" Text="UF Espedição" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListUfExpedicao" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                </div>

                <div class="container-inputs">
                    <div class="col-lg-3">
                        <asp:Label ID="LabelDataNascimento" runat="server" Text="Data Nascimento" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxDataNascimento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelSexo" runat="server" Text="Sexo" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListSexo" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelEstadoCivil" runat="server" Text="Estado Civil" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListEstadoCivil" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                </div>

                <span class="fildset-cliente">Endereço</span>

                <div class="container-inputs">

                    <div class="col-lg-3">
                        <asp:Label ID="LabelCep" runat="server" Text="Cep" CssClass="label-inputs"></asp:Label>
                        <div class="container-search">
                            <asp:TextBox ID="TextBoxCep" runat="server" CssClass="form-control col-lg-2" Enabled="false"></asp:TextBox>
                            <button type="button" class="button-search btn btn-primary" style="padding: 0">
                                <i class="fas fa-search"></i>
                            </button>
                        </div>

                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelRua" runat="server" Text="Rua" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxRua" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-1">
                        <asp:Label ID="LabelNumero" runat="server" Text="Número" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxNumero" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelComplemento" runat="server" Text="Complemento" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxComplemento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelBairro" runat="server" Text="Bairro" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxBairro" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelCidade" runat="server" Text="Cidade" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-lg-2">
                        <asp:Label ID="LabelUfEndereco" runat="server" Text="UF Endereço" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListUfEndereco" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

                </div>

                <div class="container-inputs links-acao">
                    <div>
                        <asp:HyperLink runat="server" class="btn btn-primary" NavigateUrl="~/Clientes.aspx">← Voltar</asp:HyperLink>
                    </div>
                    <div>
                        <asp:Button ID="linkEditar" Text="Editar" CssClass="retira-transform-text btn btn-success" runat="server" OnClick="Editar" />                        
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
