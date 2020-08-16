<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Endereco.ascx.cs" Inherits="WebFormsEF.Site.UserControl.Endereco" %>
<div class="form-group">
    <asp:Label ID="lblUF" runat="server" Text="UF"></asp:Label>
    <asp:DropDownList ID="ddlUF" runat="server"  CssClass="form-control" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
</div>
<div class="form-group">
    <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
    <asp:DropDownList ID="ddlCidade" runat="server"  CssClass="form-control" ></asp:DropDownList>
</div>
<div class="form-group">
    <asp:Label ID="lblLogradouro" runat="server" Text="Logradouro"></asp:Label>
    <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Label ID="lblNumero" runat="server" Text="Número"></asp:Label>
    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" ></asp:TextBox>
</div>
<div class="form-group">
    <asp:Label ID="lblCEP" runat="server" Text="CEP"></asp:Label>
    <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control" ></asp:TextBox>
</div>
