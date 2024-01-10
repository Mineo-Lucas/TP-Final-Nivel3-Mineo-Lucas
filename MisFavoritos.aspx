<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="CatalogoWeb.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color: red;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Mis Favoritos
    </h1>
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
    <div class="alert-link column-gap-lg-5 row row-cols-1 row-cols-md-3">
    <%foreach (var favorito in ListaArticulosfav)
        {%>
    <div class="card mb-3" style="max-width: 540px;">
        <div class="row g-0">
            <div class="col-md-4">
                <img src="<%: favorito.Imagen %>" class="img-fluid rounded-start" alt="...">
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <h5 class="card-title"><%: favorito.Nombre %></h5>
                    <p class="card-text"><%: favorito.Descripcion %></p>
                    <p class="card-text"><small class="text-body-secondary">precio: $<%:favorito.Precio %></small></p>
                    <p class="card-text"><small class="text-body-secondary">codigo: <%:favorito.Codigo %></small></p>
                    <a href="Eliminado.aspx?Id=<%:favorito.Id %>">Ver detalles/Eliminar de favoritos</a>
                </div>
            </div>
        </div>
    </div>
    <%} %>
        </div>
</asp:Content>
