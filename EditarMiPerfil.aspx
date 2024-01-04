<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarMiPerfil.aspx.cs" Inherits="CatalogoWeb.EditarMiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Editar Perfil</h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div>
                <asp:Label ID="Nombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="input-group-text"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
                <asp:TextBox ID="TxtApellido" runat="server" CssClass="input-group-text"></asp:TextBox>
            </div>
        </div>
                <div class="col-md-4">
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Imagen:"></asp:Label>
                        <input type="file" id="TxtImagen" runat="server" class="form-control1" />
                    </div>
                    <asp:Image ID="ImgImagen" runat="server" CssClass="img-fluid mb-3"
                        ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg" />
                </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="TxtId" runat="server" CssClass="input-group-text"></asp:TextBox>
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardar_Click"/>
            <a href="Home.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
