<%@ Page Title="Precios de venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Precios.aspx.cs" Inherits="WebSite.PreciosVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Precios de venta de películas
    </h2>
    <div class="RegSummary">
        <p>
            Editar los precios de venta.</p>
        <ul>
            <li><a href="/Alquileres/Precios.aspx">Editar precios de alquiler</a> </li>
            <li><a href="/Alquileres/Plazos.aspx">Editar plazos de alquiler</a> </li>
        </ul>
    </div>
    <table class="RegPrecios">
        <tbody>
            <tr>
                <th>
                </th>
                <th>
                    DVD
                </th>
            </tr>
            <tr>
                <th>
                    Socio
                </th>
                <td>
                    <asp:TextBox ID="TBSocio" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Particular
                </th>
                <td>
                    <asp:TextBox ID="TBParticular" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="lastRow">
                    <asp:Button runat="server" ID="BActualizar" Text="Actualizar" 
                        onclick="BActualizar_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
