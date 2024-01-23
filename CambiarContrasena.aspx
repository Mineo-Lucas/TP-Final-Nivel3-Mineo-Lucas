<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="CatalogoWeb.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Cambiar Contraseña
    </h1>
    <div>
       <asp:Label ID="Label1" runat="server" Text="Contraseña actual:"></asp:Label>
        <asp:TextBox ID="TxtContraseñaactual" runat="server" CssClass="input-group-text" TextMode="Password"></asp:TextBox>
    </div>
    <div>
       <asp:Label ID="Label2" runat="server" Text="Nueva Contraseña:"></asp:Label>
        <asp:TextBox ID="TxtNuevaContraseña" runat="server" CssClass="input-group-text" TextMode="Password"></asp:TextBox>
    </div>
    <div>
       <asp:Label ID="Label3" runat="server" Text="Repeti la nueva contraseña:"></asp:Label>
        <asp:TextBox ID="TxtNuevaContraseña2" runat="server" CssClass="input-group-text" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="BtnCambiarContraseña" runat="server" Text="Cambiar" CssClass="btn btn-warning" OnClick="BtnCambiarContraseña_Click"/>
        <a href="Default.aspx">Cancelar</a>
    </div>
</asp:Content>
