<%@ Page Title="El sétimo arte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="WebSite.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sistema administrativo
    </h2>
    <div id="Registros" class="MenuBlock">
        <h3>
            Registros
        </h3>
        <ul>
            <li><h4><a href="Alquileres/Registrar.aspx">Alquileres</a></h4></li>
            <li><h4><a href="Ventas/Registrar.aspx">Ventas</a></h4></li>
            <li><h4><a href="Clientes/Registrar.aspx">Clientes</a></h4></li>
            <li><h4><a href="Inventario/Registrar.aspx">Película</a></h4></li>
            <li><h4><a href="Alquileres/Pendientes.aspx">Devolución</a></h4></li>
        </ul>
    </div>
    <div id="Informes" class="MenuBlock">
        <h3>
            Informes
        </h3>
        <ul>
            <li><h4><a href="Alquileres/Informes.aspx">Alquileres</a></h4></li>
            <li><h4><a href="Ventas/Informes.aspx">Ventas</a></h4></li>
        </ul>
    </div>
    <div id="Búsquedas" class="MenuBlock">
        <h3>
            Búsquedas
        </h3>
        <ul>
            <li><h4><a href="Clientes/Buscar.aspx">Clientes</a></h4></li>
            <li><h4><a href="Inventario/Buscar.aspx">Películas</a></h4></li>
        </ul>
    </div>
    <div id="Precios" class="MenuBlock">
        <h3>
            Otros
        </h3>
        <ul>
            <li><h4><a href="Alquileres/Plazos.aspx">Plazos de alquiler</a></h4></li>
            <li><h4><a href="Alquileres/Precios.aspx">Precios de alquiler</a></h4></li>
            <li><h4><a href="Ventas/Precios.aspx">Precios de venta</a></h4></li>
            <li><h4><a href="Inventario/Categorías.aspx">Categorías de películas</a></h4></li>
        </ul>
    </div>
</asp:Content>
