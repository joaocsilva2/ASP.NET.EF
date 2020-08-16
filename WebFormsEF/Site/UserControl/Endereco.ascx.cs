using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsEF.Site.UserControl
{
    public partial class Endereco : System.Web.UI.UserControl
    {
        public int CodigoUF
        {
            get { return Convert.ToInt32(ddlUF.SelectedValue); }
            set { ddlUF.SelectedValue = value.ToString(); }
        }

        public int CodigoCidade
        {
            get { return Convert.ToInt32(ddlCidade.SelectedValue); }
            set { ddlCidade.SelectedValue = value.ToString(); }
        }
        public string Logradouro
        {
            get { return txtLogradouro.Text; }
            set { txtLogradouro.Text = value.ToString(); }
        }

        public string Numero
        {
            get { return txtNumero.Text; }
            set { txtNumero.Text = value.ToString(); }
        }

        public string CEP
        {
            get { return txtCEP.Text; }
            set { txtCEP.Text = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                CarregarComponentes();
            }
        }

        private void CarregarComponentes()
        {
            CarregarUF();
            CarregarCidades(-1);

        }
        private void CarregarUF()
        {
            var ufSrv = new UFService();
            ddlUF.DataSource = ufSrv.Listar();
            ddlUF.DataTextField = "Nome";
            ddlUF.DataValueField = "ID";
            ddlUF.DataBind();

            ddlUF.Items.Insert(0, new ListItem("Selecione uma UF", "-1"));
        }
        private void CarregarCidades(int codigoUF)
        {
            if(codigoUF > 0)
            {
                var cidSrv = new CidadeService();
                ddlCidade.DataSource = cidSrv.Listar(codigoUF);
                ddlCidade.DataTextField = "Nome";
                ddlCidade.DataValueField = "ID";
                ddlCidade.DataBind();
            }
            else
            {
                ddlCidade.DataSource = null;
                ddlCidade.DataBind();
            }

            ddlCidade.Items.Insert(0, new ListItem("Selecione uma Cidade", "-1"));
        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCidades(Convert.ToInt32(ddlUF.SelectedValue));
        }
    }
}