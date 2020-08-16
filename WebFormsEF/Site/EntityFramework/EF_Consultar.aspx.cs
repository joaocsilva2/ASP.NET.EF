using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;

namespace WebFormsEF.Site.EntityFramework
{
    public partial class EF_Consultar : System.Web.UI.Page
    {
        public ClienteService cliSrv = new ClienteService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var lista = cliSrv.Listar();
            gdvDados.DataSource = lista;
            gdvDados.DataBind();
        }
    }
}