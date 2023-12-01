<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CatalogoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Error
        </h1>
    </div>
    <div>
        <asp:Label ID="LblError" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <a href="Home.aspx">Volver al home</a>
    </div>

</asp:Content>
