using System;
using WebForm.ClienteServiceReference;

namespace WebForm
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var servico = new ClienteServiceClient();
                GridView1.DataSource = servico.RetornaClientes();
                GridView1.DataBind();
            }
        }
    }
}