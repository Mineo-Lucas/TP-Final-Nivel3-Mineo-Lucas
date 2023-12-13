<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoDeUsuarios.aspx.cs" Inherits="CatalogoWeb.ListadoDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Listado de usuarios
        </h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Campo"></asp:Label>
        <asp:DropDownList ID="DdpCampo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdpCampo_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Criterio"></asp:Label>
        <asp:DropDownList ID="DdpCriterio" runat="server"></asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Filtro"></asp:Label>
        <asp:TextBox ID="TxtFiltro" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" onclick="BtnBuscar_Click"/>
    </div>
    <div>
        <asp:GridView ID="GdvPerfiles" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-dark border-danger"
            OnSelectedIndexChanged="GdvPerfiles_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" /> 
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Contraseña" DataField="Contraseña" /> 
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" /> 
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" /> 
                <asp:BoundField HeaderText="Imagen" DataField="Imagen" /> 
                <asp:BoundField HeaderText="Admin" DataField="Admin" />
                <asp:CommandField HeaderText="Modificar/Eliminar" ShowSelectButton="true" SelectText="Selecccionar"/>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
