<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarCatalogo.aspx.cs" Inherits="CatalogoWeb.EditarCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h1>Editar Catalogo
        </h1>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="DdlCampo" runat="server" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="Criterio:"></asp:Label>
                <asp:DropDownList ID="DdlCriterio" runat="server"></asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="Filtro:"></asp:Label>
                <asp:TextBox ID="TxtFiltroAvanzado" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="solo numeros" CssClass="validacion" ValidationExpression="^[0-9]+$" ID="RevFiltro" ControlToValidate="TxtFiltroAvanzado" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" />
    </div>
    <asp:GridView runat="server" ID="DgvEditarCatalogo"
        DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-dark border-danger" 
        OnSelectedIndexChanged="DgvEditarCatalogo_SelectedIndexChanged" OnPageIndexChanging="DgvEditarCatalogo_PageIndexChanging"
        AllowPaging="true" PageSize="7">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Imagen" DataField="Imagen" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}"/>
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnAgregarArticulo" runat="server" CssClass="btn btn-primary" Text="Agregar Articulo" OnClick="BtnAgregarArticulo_Click" />
    <a href="Default.aspx">Volver al home</a>
</asp:Content>
