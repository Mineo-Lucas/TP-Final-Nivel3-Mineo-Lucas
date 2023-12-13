<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarUsers.aspx.cs" Inherits="CatalogoWeb.EditarUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Modificar Articulo
        </h1>
    </div>
    <div>
        <asp:Label ID="Label8" runat="server" Text="Id:"></asp:Label>
        <asp:TextBox ID="TxtId" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="Label5" runat="server" Text="Pass:"></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
    
    <div>
        <asp:Label ID="Label4" runat="server" Text="Imagen:"></asp:Label>
        <asp:TextBox ID="TxtImagen" runat="server" CssClass="input-group-text"></asp:TextBox>
    </div>
   
    <div>
        <asp:Label ID="Label6" runat="server" Text="Admin:"></asp:Label>
        <asp:CheckBox ID="CbxAdmin" runat="server"/>
    </div>
    <div>
        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" "btn btn-warning" Onclick="BtnModificar_Click"/>
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" "btn btn-danger" OnClick="BtnEliminar_Click"/>
        <a href="ListadoDeUsuarios.aspx">Cancelar</a>
    </div>
</asp:Content>
