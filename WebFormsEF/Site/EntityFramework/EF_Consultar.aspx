<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EF_Consultar.aspx.cs" Inherits="WebFormsEF.Site.EntityFramework.EF_Consultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Página com Entity Framework</h3>

    <div class="form-group">
        <asp:Button ID="btnPesquisar" runat="server" CssClass="btn" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    </div>

    <asp:GridView ID="gdvDados" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="false" GridLines="None">
        <Columns>
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEditar" CssClass="btn btn-primary" Text="Editar" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEcluir" CssClass="btn btn-danger" Text="Excluir" CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
