using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Entities;
using Service;


namespace WebFormsEF.Site.Cliente
{
    public partial class Cadastro : System.Web.UI.Page
    {
        public ClienteService cliSrv = new ClienteService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int codigo = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    CarregarDados(codigo);
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.Entities.Cliente cliente = new Domain.Entities.Cliente();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    cliente.ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                }
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Logradouro = Endereco.Logradouro;
                cliente.Numero = Endereco.Numero;
                cliente.Cep = Endereco.CEP;
                cliente.UF = new UF() { ID = Endereco.CodigoUF };
                cliente.Cidade = new Cidade() { ID = Endereco.CodigoCidade,UF = cliente.UF };
                cliSrv.Salvar(cliente);
                Response.Redirect("ListarCliente.aspx", true);
            }
            catch (Exception ex)
            {
                msg.InnerText = ex.Message;
            }
        }

        public void CarregarDados(int codigo)
        {
            try
            {
                var cli = cliSrv.ListarPorID(codigo);
                txtCPF.Text = cli.CPF;
                txtNome.Text = cli.Nome;
                txtTelefone.Text = cli.Telefone;
                Endereco.Logradouro = cli.Logradouro;
                Endereco.Numero = cli.Numero;
                Endereco.CEP = cli.Cep;
                Endereco.CodigoUF = cli.UF.ID;
                Endereco.CodigoCidade = cli.Cidade.ID;
            }
            catch
            {

            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarCliente.aspx", true);
        }
    }
}