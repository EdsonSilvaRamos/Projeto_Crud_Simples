using System;
using WebForm.ClienteServiceReference;
using WebForm.Utils;

namespace WebForm
{
    public partial class EditarCliente : System.Web.UI.Page
    {
        private ClienteServiceClient Servico;
        private int IdCliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            Servico = new ClienteServiceClient();
            IdCliente = Convert.ToInt32(Request.QueryString["Id"]);

            if (!this.IsPostBack)
            {
                var cliente = Servico.RetornaClientePor(IdCliente);

                TextBoxCPF.Text = cliente.CPF;
                TextBoxNome.Text = cliente.Nome;
                TextBoxRG.Text = cliente.RG;
                TextBoxDataExpedicao.Text = cliente.DataExpedicao.ToString("dd/MM/yyyy");
                TextBoxDataNascimento.Text = cliente.DataNascimento.ToString("dd/MM/yyyy");

                TextBoxCep.Text = cliente.Enderecos.CEP;
                TextBoxRua.Text = cliente.Enderecos.Logradouro;
                TextBoxNumero.Text = cliente.Enderecos.Numero;
                TextBoxComplemento.Text = cliente.Enderecos.Complemento;
                TextBoxBairro.Text = cliente.Enderecos.Bairro;
                TextBoxCidade.Text = cliente.Enderecos.Cidade;

                DropDownListOrgaoExpedicao.DataSource = Utilidades.RetornaDicionarioOrgaoExpedicao();
                DropDownListOrgaoExpedicao.DataTextField = "Key"; ;
                DropDownListOrgaoExpedicao.DataValueField = "Value";
                DropDownListOrgaoExpedicao.DataBind();
                DropDownListOrgaoExpedicao.Items.FindByText(cliente.OrgaoExpedicao).Selected = true;

                DropDownListUfExpedicao.DataSource = Utilidades.RetornaDicionarioUf();
                DropDownListUfExpedicao.DataTextField = "Key"; ;
                DropDownListUfExpedicao.DataValueField = "Value";
                DropDownListUfExpedicao.DataBind();
                DropDownListUfExpedicao.Items.FindByText(cliente.UF).Selected = true;

                DropDownListSexo.DataSource = Utilidades.RetornaDicionarioGenero();
                DropDownListSexo.DataTextField = "Key"; ;
                DropDownListSexo.DataValueField = "Value";
                DropDownListSexo.DataBind();
                DropDownListSexo.Items.FindByText(cliente.Sexo).Selected = true;

                DropDownListEstadoCivil.DataSource = Utilidades.RetornaDicionarioEstadoCivil();
                DropDownListEstadoCivil.DataTextField = "Key"; ;
                DropDownListEstadoCivil.DataValueField = "Value";
                DropDownListEstadoCivil.DataBind();
                DropDownListEstadoCivil.Items.FindByText(cliente.EstadoCivil).Selected = true;

                DropDownListUfEndereco.DataSource = Utilidades.RetornaDicionarioUf();
                DropDownListUfEndereco.DataTextField = "Key"; ;
                DropDownListUfEndereco.DataValueField = "Value";
                DropDownListUfEndereco.DataBind();
                DropDownListUfEndereco.Items.FindByText(cliente.Enderecos.UF).Selected = true;

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var clienteEnderecoDTO = new ClienteEnderecoDTO();

            clienteEnderecoDTO.ClienteId = IdCliente;
            clienteEnderecoDTO.CPF = TextBoxCPF.Text;
            clienteEnderecoDTO.Nome = TextBoxNome.Text;
            clienteEnderecoDTO.RG = TextBoxRG.Text;
            clienteEnderecoDTO.DataExpedicao = Convert.ToDateTime(TextBoxDataExpedicao.Text);
            clienteEnderecoDTO.OrgaoExpedicao = DropDownListOrgaoExpedicao.SelectedItem.ToString();
            clienteEnderecoDTO.UfExpedicao = DropDownListUfExpedicao.SelectedItem.ToString();
            clienteEnderecoDTO.DataNascimento = Convert.ToDateTime(TextBoxDataNascimento.Text);
            clienteEnderecoDTO.Sexo = DropDownListSexo.SelectedItem.ToString();
            clienteEnderecoDTO.EstadoCivil = DropDownListEstadoCivil.SelectedItem.ToString();

            clienteEnderecoDTO.CEP = TextBoxCep.Text;
            clienteEnderecoDTO.Logradouro = TextBoxRua.Text;
            clienteEnderecoDTO.Numero = TextBoxNumero.Text;
            clienteEnderecoDTO.Complemento = TextBoxComplemento.Text;
            clienteEnderecoDTO.Bairro = TextBoxBairro.Text;
            clienteEnderecoDTO.Cidade = TextBoxCidade.Text;
            clienteEnderecoDTO.UfEndereco = DropDownListUfEndereco.SelectedItem.ToString();

            try
            {
                Servico.AtualizaCliente(clienteEnderecoDTO);
            }
            catch (Exception)
            {

            }

            Response.Redirect("Clientes.aspx");
        }
    }
}