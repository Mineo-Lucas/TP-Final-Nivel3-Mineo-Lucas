<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Loguearse.aspx.cs" Inherits="CatalogoWeb.Loguearse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <h1>
        Loguearse
    </h1>
</div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="TxtContraseña" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="BtnLoguearse" runat="server" Text="Loguearse" />
        <a href="Home.aspx">Cancelar</a>
    </div>
</asp:Content>
