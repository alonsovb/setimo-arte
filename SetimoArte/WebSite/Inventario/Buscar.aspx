<%@ Page Title="Buscar película" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Buscar.aspx.cs" Inherits="WebSite.BuscarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Búsqueda de películas
    </h2>
    <div class="BuscDiv">
        <p>
            Seleccione el código o el nombre de la película a buscar.</p>
        <table>
            <tbody>
                <tr>
                    <td>
                        Código
                    </td>
                    <td>
                        <asp:TextBox ID="TBCódigo" runat="server" CssClass="RegForm"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre
                    </td>
                    <td>
                        <asp:TextBox ID="TBNombre" runat="server" CssClass="RegForm"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="lastRow">
                        <asp:Button runat="server" ID="BBuscar" Text="Buscar" OnClick="BBuscar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <ul>
            <li><a href="/Clientes/Buscar.aspx">Buscar cliente</a> </li>
        </ul>
    </div>
    <div class="ResDiv">
        <asp:Label ID="LBuscar" runat="server" Text="" CssClass="RegForm"></asp:Label>
        <asp:GridView ID="GVLista" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
