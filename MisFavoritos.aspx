<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="CatalogoWeb.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mis Favoritos
    </h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Campo:"></asp:Label>
        <asp:DropDownList ID="DdlCampo" runat="server" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Criterio:"></asp:Label>
        <asp:DropDownList ID="DdlCriterio" runat="server"></asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Filtro:"></asp:Label>
        <asp:TextBox ID="TxtFiltroAvanzado" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" />
    </div>
    <%foreach (var favorito in ListaArticulosfav)
        {%>
    <div class="card mb-3" style="max-width: 540px;">
        <div class="row g-0">
            <div class="col-md-4">
                <img src="..." class="img-fluid rounded-start" alt="...">
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <h5 class="card-title"><%: favorito.Nombre %></h5>
                    <p class="card-text"><%: favorito.Descripcion %></p>
                    <p class="card-text"><small class="text-body-secondary"><%:favorito.Precio %></small></p>
                </div>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
