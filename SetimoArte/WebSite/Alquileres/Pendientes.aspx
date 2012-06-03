<%@ Page Title="Pendientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Pendientes.aspx.cs" Inherits="WebSite.AlquileresPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pendientes">
        <h2>
            Alquileres pendientes
        </h2>
        <asp:GridView ID="GVPendientes" runat="server" AutoGenerateColumns="False" CssClass="Gridview">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id_alquileres" DataNavigateUrlFormatString="Devolución.aspx?id={0}"
                    DataTextField="id_alquileres" DataTextFormatString="Ver alquiler" HeaderText="Alquiler" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="entrega" HeaderText="Fecha entrega" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="activos">
        <h2>
            Alquileres activos
        </h2>
        <asp:GridView ID="GVActivos" runat="server" AutoGenerateColumns="False" CssClass="Gridview">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id_alquileres" DataNavigateUrlFormatString="Devolución.aspx?id={0}"
                    DataTextField="id_alquileres" DataTextFormatString="Ver alquiler" HeaderText="Alquiler" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="entrega" HeaderText="Fecha entrega" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
