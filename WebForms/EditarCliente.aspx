<%@ Page Title="Editar Dados do Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCliente.aspx.cs" Inherits="WebForm.EditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="principal">

        <div class="corrige-layout-telas">

            <h2>Editar Dados do Cliente</h2>

            <div class="form-horizontal">

                <hr />

                <span class="fildset-cliente">Cliente</span>

                <div class="container-inputs">
                    <div class="col-lg-2">
                        <asp:Label ID="LabelCPF" runat="server" Text="CPF" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxCPF" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPF" runat="server" ErrorMessage="O campo CPF é Obrigatório" ControlToValidate="TextBoxCPF"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-12">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxNome" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNome" runat="server" ErrorMessage="O campo Nome é Obrigatório" ControlToValidate="TextBoxNome"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="container-inputs">
                    <div class="col-lg-3">
                        <asp:Label ID="LabelRG" runat="server" Text="RG" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxRG" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRG" runat="server" ErrorMessage="O campo RG é Obrigatório" ControlToValidate="TextBoxRG"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelDataExpedicao" runat="server" Text="Data Expedição" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxDataExpedicao" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDataExpedicao" runat="server" ErrorMessage="O campo Data Expedição é Obrigatório" ControlToValidate="TextBoxDataExpedicao"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelOrgaoExpedicao" runat="server" Text="Orgao Espedição" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListOrgaoExpedicao" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrgaoExpedicao" runat="server" ErrorMessage="O campo Orgao Espedição é Obrigatório" ControlToValidate="DropDownListOrgaoExpedicao" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelUfExpedicao" runat="server" Text="UF Espedição" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListUfExpedicao" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUfExpedicao" runat="server" ErrorMessage="O campo UF Espedição é Obrigatório" ControlToValidate="DropDownListUfExpedicao" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="container-inputs">
                    <div class="col-lg-3">
                        <asp:Label ID="LabelDataNascimento" runat="server" Text="Data Nascimento" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxDataNascimento" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDataNascimento" runat="server" ErrorMessage="O campo Data Nascimento é Obrigatório" ControlToValidate="TextBoxDataNascimento"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelSexo" runat="server" Text="Sexo" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListSexo" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="O campo Sexo é Obrigatório" ControlToValidate="DropDownListSexo" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelEstadoCivil" runat="server" Text="Estado Civil" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListEstadoCivil" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEstadoCivil" runat="server" ErrorMessage="O campo Estado Civil é Obrigatório" ControlToValidate="DropDownListEstadoCivil" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <span class="fildset-cliente">Endereço</span>

                <div class="container-inputs">

                    <div class="col-lg-3">
                        <asp:Label ID="LabelCep" runat="server" Text="Cep" CssClass="label-inputs"></asp:Label>
                        <div class="container-search">
                            <asp:TextBox ID="TextBoxCep" runat="server" CssClass="form-control col-lg-2"></asp:TextBox>
                            <button type="button" class="button-search btn btn-primary" style="padding: 0">
                                <i class="fas fa-search"></i>
                            </button>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCep" runat="server" ErrorMessage="O campo Cep é Obrigatório" ControlToValidate="TextBoxCPF"></asp:RequiredFieldValidator>

                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelRua" runat="server" Text="Rua" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxRua" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRua" runat="server" ErrorMessage="O campo Rua é Obrigatório" ControlToValidate="TextBoxRua"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-1">
                        <asp:Label ID="LabelNumero" runat="server" Text="Número" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxNumero" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumero" runat="server" ErrorMessage="O campo Número é Obrigatório" ControlToValidate="TextBoxNumero"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelComplemento" runat="server" Text="Complemento" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxComplemento" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorComplemento" runat="server" ErrorMessage="O campo Complemento é Obrigatório" ControlToValidate="TextBoxComplemento"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelBairro" runat="server" Text="Bairro" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxBairro" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBairro" runat="server" ErrorMessage="O campo Bairro é Obrigatório" ControlToValidate="TextBoxBairro"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-3">
                        <asp:Label ID="LabelCidade" runat="server" Text="Cidade" CssClass="label-inputs"></asp:Label>
                        <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCidade" runat="server" ErrorMessage="O campo Cidade é Obrigatório" ControlToValidate="TextBoxCidade"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-2">
                        <asp:Label ID="LabelUfEndereco" runat="server" Text="UF Endereço" CssClass="label-inputs"></asp:Label>
                        <asp:DropDownList ID="DropDownListUfEndereco" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUfEndereco" runat="server" ErrorMessage="O campo UF Endereço é Obrigatório" ControlToValidate="DropDownListUfEndereco" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>

                </div>

                <div class="container-inputs links-acao">
                    <div>
                        <asp:HyperLink runat="server" class="btn btn-primary" NavigateUrl="~/Clientes.aspx">← Voltar</asp:HyperLink>
                    </div>
                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Atualizar →" CssClass="retira-transform-text tamanho-links-acao btn btn-default" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
