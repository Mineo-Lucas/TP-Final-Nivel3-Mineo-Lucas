<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarCatalogo.aspx.cs" Inherits="CatalogoWeb.EditarCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Editar Catalogo
    </h1>
    <asp:GridView runat="server" ID="DgvEditarCatalogo"
        DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-dark border-danger"
        OnSelectedIndexChanged="DgvEditarCatalogo_SelectedIndexChanged" OnSelectedPageChanging="DgvEditarCatalogo_SelectedIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Imagen" DataField="Imagen" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <a href="Home.aspx">Volver</a>
</asp:Content>
