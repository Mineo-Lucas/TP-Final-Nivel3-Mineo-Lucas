<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="CatalogoWeb.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Registro
    </h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email" CssClass="input-group-text"></asp:TextBox>
        <asp:RegularExpressionValidator ErrorMessage="tiene que contener formato Email" CssClass="validacion" ControlToValidate="TxtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="TxtContraseña" runat="server" TextMode="Password" CssClass="input-group-text"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="BtnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="BtnRegistrarse_Click"/>
        <a href="Default.aspx">Cancelar</a>
    </div>
</asp:Content>
