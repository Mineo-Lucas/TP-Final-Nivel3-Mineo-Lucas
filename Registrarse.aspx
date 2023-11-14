<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="CatalogoWeb.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Registro
    </h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="TxtContraseña" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="BtnRegistrarse" runat="server" Text="Registrarse" OnClick="BtnRegistrarse_Click"/>
        <a href="Home.aspx">Cancelar</a>
    </div>
</asp:Content>
