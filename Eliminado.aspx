﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Eliminado.aspx.cs" Inherits="CatalogoWeb.Eliminado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Nombre
        </h1>
    </div>
     <div>
        <asp:Label ID="LblDescripcion" runat="server" Text="descripcion"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label4" runat="server" Text="Precio:"></asp:Label>
        <asp:Label ID="LblPrecio" runat="server" Text=""></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label7" runat="server" Text="Codigo"></asp:Label>
        <asp:Label ID="LblCodigo" runat="server" Text=""></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label9" runat="server" Text="Marca:"></asp:Label>
        <asp:Label ID="LblMarca" runat="server" Text=""></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label1" runat="server" Text="Categoria:"></asp:Label>
        <asp:Label ID="LblCategoria" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnEliminarFavorito" runat="server" Text="Eliminar de favoritos" CssClass="btn btn-danger" OnClick="BtnEliminarFavorito_Click"/>
        <a href="MisFavoritos.aspx">Volver</a>
    </div>
</asp:Content>
