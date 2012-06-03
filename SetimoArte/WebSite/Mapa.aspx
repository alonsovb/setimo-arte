<%@ Page Title="Mapa del sitio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Mapa.aspx.cs" Inherits="WebSite.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Mapa del sitio
    </h2>
    <div class="MenuBlock">
        <h3>
            <a href="Alquileres/">Alquileres</a>
        </h3>
        <ul>
            <li>
                <h4>
                    <a href="Alquileres/Registrar.aspx">Registrar alquiler</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Alquileres/Informes.aspx">Informes</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Alquileres/Pendientes.aspx">Pendientes</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Alquileres/Precios.aspx">Precios</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Alquileres/Plazos.aspx">Plazos</a>
                </h4>
            </li>
        </ul>
    </div>
    <div class="MenuBlock">
        <h3>
            <a href="Ventas/">Ventas</a>
        </h3>
        <ul>
            <li>
                <h4>
                    <a href="Ventas/Registrar.aspx">Registrar venta</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Ventas/Informes.aspx">Informes</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Ventas/Precios.aspx">Precios</a>
                </h4>
            </li>
        </ul>
    </div>
    <div class="MenuBlock">
        <h3>
            <a href="Clientes/">Clientes</a>
        </h3>
        <ul>
            <li>
                <h4>
                    <a href="Clientes/Registrar.aspx">Registrar cliente</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Clientes/Buscar.aspx">Buscar</a>
                </h4>
            </li>
        </ul>
    </div>
        <div class="MenuBlock">
        <h3>
            <a href="Inventario/">Películas</a>
        </h3>
        <ul>
            <li>
                <h4>
                    <a href="Inventario/Registrar.aspx">Registrar película</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Inventario/Buscar.aspx">Buscar</a>
                </h4>
            </li>
            <li>
                <h4>
                    <a href="Inventario/Categorías.aspx">Categorías</a>
                </h4>
            </li>
        </ul>
    </div>
</asp:Content>
