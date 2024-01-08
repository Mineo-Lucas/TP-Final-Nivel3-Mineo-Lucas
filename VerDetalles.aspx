<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerDetalles.aspx.cs" Inherits="CatalogoWeb.VerDetalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Nombre
        </h1>
    </div>
    <div>
        <asp:Image ID="ImgArticulo" runat="server" />
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
        <asp:Button ID="BtnAgregarFavorito" runat="server" Text="Agregar a favoritos" CssClass="btn btn-warning" OnClick="BtnAgregarFavorito_Click"/>
        <a href="Home.aspx">Volver</a>
    </div>
</asp:Content>
