<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Categorías.aspx.cs" Inherits="WebSite.Categorías" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mask">
    </div>
    <h2>
        Categorías
    </h2>
    <a href="#dialog" name="modal">Agregar nueva categoría</a>
    <div id="boxes">
        <div id="dialog" class="window">
            <h3>
                Agregar nueva
            </h3>
            <asp:TextBox ID="TBNombre" runat="server" placeholder="Nombre" CssClass="RegForm"></asp:TextBox>
            <asp:Button runat="server" ID="BAgregar" Text="Agregar" OnClick="AgregarClicked" />
        </div>
    </div>
    <div class="ListBlock">
        <asp:GridView ID="GridLista" runat="server" CssClass="Gridview">
        </asp:GridView>
    </div>
</asp:Content>
