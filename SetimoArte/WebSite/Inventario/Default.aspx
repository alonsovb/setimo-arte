<%@ Page Title="Inventario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Películas
    </h2>
    <ul>
        <li>
            <h3>
                <a href="Registrar.aspx">Registrar</a>
            </h3>
        </li>
        <li>
            <h3>
                <a href="Buscar.aspx">Búsqueda</a>
            </h3>
        </li>
        <li>
            <h3>
                <a href="Categorías.aspx">Categorías</a>
            </h3>
        </li>
    </ul>
</asp:Content>
