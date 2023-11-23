<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarMiPerfil.aspx.cs" Inherits="CatalogoWeb.EditarMiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Editar Perfil</h1>
    </div>
    <div>
        <asp:Label ID="Nombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Imagen:"></asp:Label>
        <asp:TextBox ID="TxtImagen" runat="server"></asp:TextBox>
        <asp:Image ID="ImgImagen" runat="server" />
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
        <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="TxtGuardar" runat="server" Text="Guardar" Onclick="TxtGuardar_Click"/>
        <a href="Home.aspx">Cancelar</a>
    </div>
</asp:Content>
