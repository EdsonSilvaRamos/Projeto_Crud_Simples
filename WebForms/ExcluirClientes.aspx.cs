using System;
using WebForm.ClienteServiceReference;

namespace WebForm
{
    public partial class ExcluirClientes : System.Web.UI.Page
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

                LabelCPF.Text = cliente.CPF;
                LabelNome.Text = cliente.Nome;
                LabelRG.Text = cliente.RG;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Servico.ExcluiClientePor(IdCliente);
            }
            catch (Exception)
            {

            }

            Response.Redirect("Clientes.aspx");
        }

    }
}