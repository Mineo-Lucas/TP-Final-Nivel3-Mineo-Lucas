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
        <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Imagen:"></asp:Label>
        <asp:TextBox ID="TxtImagen" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Pass:"></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label6" runat="server" Text="Marca:"></asp:Label>
        <asp:DropDownList ID="DdlMarca" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Label7" runat="server" Text="Categoria:"></asp:Label>
        <asp:DropDownList ID="DdlCategoria" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="BtnAceptar" runat="server" Text="Agregar" OnClick="BtnAceptar_Click"/>
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click"/>
        <a href="EditarCatalogo.aspx">Cancelar</a>
    </div>
</asp:Content>
