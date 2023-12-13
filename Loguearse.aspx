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
        <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="TxtContraseña" runat="server" TextMode="Password" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="BtnLoguearse" runat="server" Text="Loguearse" CssClass="btn btn-primary" onclick="BtnLoguearse_Click"/>
        <a href="Home.aspx">Cancelar</a>
    </div>
</asp:Content>
