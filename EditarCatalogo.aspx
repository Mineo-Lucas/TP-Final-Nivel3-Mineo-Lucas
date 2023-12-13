<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarCatalogo.aspx.cs" Inherits="CatalogoWeb.EditarCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Editar Catalogo
    </h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Campo:"></asp:Label>
        <asp:DropDownList ID="DdlCampo" runat="server" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Criterio:"></asp:Label>
        <asp:DropDownList ID="DdlCriterio" runat="server"></asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Filtro:"></asp:Label>
        <asp:TextBox ID="TxtFiltroAvanzado" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click"/>
    </div>
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
