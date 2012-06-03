<%@ Page Title="Devolución" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Devolución.aspx.cs" Inherits="WebSite.AlquilerDevolución" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Devolución de alquiler
    </h2>
    <asp:GridView ID="GVAlquiler" runat="server" CssClass="Gridview" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id_alquileres" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="entrega" HeaderText="Fecha de entrega" />
            <asp:BoundField DataField="costo" HeaderText="Costo" />
        </Columns>

    </asp:GridView>

    <asp:GridView ID="GVAlquilerPelícula" runat="server" CssClass="Gridview" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Películas" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BDevolver" runat="server" Text="Registrar Devolución" 
        onclick="BDevolver_Click" />
</asp:Content>
