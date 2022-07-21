using System;
using WebForm.ClienteServiceReference;
using WebForm.Utils;

namespace WebForm
{
    public partial class CadastrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownListOrgaoExpedicao.DataSource = Utilidades.RetornaDicionarioOrgaoExpedicao();
                DropDownListOrgaoExpedicao.DataTextField = "Key"; ;
                DropDownListOrgaoExpedicao.DataValueField = "Value";
                DropDownListOrgaoExpedicao.Text = "";
                DropDownListOrgaoExpedicao.DataBind();

                DropDownListUfExpedicao.DataSource = Utilidades.RetornaDicionarioUf();
                DropDownListUfExpedicao.DataTextField = "Key"; ;
                DropDownListUfExpedicao.DataValueField = "Value";
                DropDownListUfExpedicao.Text = "";
                DropDownListUfExpedicao.DataBind();

                DropDownListSexo.DataSource = Utilidades.RetornaDicionarioGenero();
                DropDownListSexo.DataTextField = "Key"; ;
                DropDownListSexo.DataValueField = "Value";
                DropDownListSexo.Text = "";
                DropDownListSexo.DataBind();

                DropDownListEstadoCivil.DataSource = Utilidades.RetornaDicionarioEstadoCivil();
                DropDownListEstadoCivil.DataTextField = "Key"; ;
                DropDownListEstadoCivil.DataValueField = "Value";
                DropDownListEstadoCivil.Text = "";
                DropDownListEstadoCivil.DataBind();

                DropDownListUfEndereco.DataSource = Utilidades.RetornaDicionarioUf();
                DropDownListUfEndereco.DataTextField = "Key"; ;
                DropDownListUfEndereco.DataValueField = "Value";
                DropDownListUfEndereco.Text = "";
                DropDownListUfEndereco.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var servico = new ClienteServiceClient();
            var cliente = new ClienteServiceReference.Clientes();

            cliente.CPF = TextBoxCPF.Text;
            cliente.Nome = TextBoxNome.Text;
            cliente.RG = TextBoxRG.Text;
            cliente.DataExpedicao = Convert.ToDateTime(TextBoxDataExpedicao.Text);
            cliente.OrgaoExpedicao = DropDownListOrgaoExpedicao.SelectedItem.ToString();
            cliente.UF = DropDownListUfExpedicao.SelectedItem.ToString();
            cliente.DataNascimento = Convert.ToDateTime(TextBoxDataNascimento.Text);
            cliente.Sexo = DropDownListSexo.SelectedItem.ToString();
            cliente.EstadoCivil = DropDownListEstadoCivil.SelectedItem.ToString();

            cliente.Enderecos = new Enderecos();

            cliente.Enderecos.CEP = TextBoxCep.Text;
            cliente.Enderecos.Logradouro = TextBoxRua.Text;
            cliente.Enderecos.Numero = TextBoxNumero.Text;
            cliente.Enderecos.Complemento = TextBoxComplemento.Text;
            cliente.Enderecos.Bairro = TextBoxBairro.Text;
            cliente.Enderecos.Cidade = TextBoxCidade.Text;
            cliente.Enderecos.UF = DropDownListUfEndereco.SelectedItem.ToString();

            try
            {
                servico.AdicionaCliente(cliente);
            }
            catch (Exception)
            {
                
            }

            Response.Redirect("Clientes.aspx");
        }
    }
}