<%@ Page Title="Informes de ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="WebSite.InformesVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Informes de ventas
    </h2>
    <div class="BuscDiv">
        <p>
            Seleccione las fechas de inicio y final para el reporte.</p>
        <table>
            <tbody>
                <tr>
                    <td>
                        Inicio
                    </td>
                    <td>
                        <asp:Calendar ID="CInicio" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        Final
                    </td>
                    <td>
                        <asp:Calendar ID="CFinal" runat="server" ></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        Socio <i>(opcional)</i>
                    </td>
                    <td>
                        <asp:TextBox ID="TBSocio" runat="server" CssClass="RegForm"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="lastRow">
                        <asp:Button runat="server" ID="BBuscar" Text="Aceptar" 
                            onclick="BBuscar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <ul>
            <li><a href="/Alquileres/Informes.aspx">Informe de alquileres</a> </li>
        </ul>
    </div>
    <div class="ResDiv">
        <asp:Label ID="LBuscar" runat="server" Text="" CssClass="RegForm"></asp:Label>
        <asp:GridView ID="GVLista" runat="server" CssClass="Gridview">
        </asp:GridView>
    </div>
</asp:Content>
