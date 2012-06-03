<%@ Page Title="Plazos de alquiler" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Plazos.aspx.cs" Inherits="WebSite.PlazosAlquileres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Plazos de alquiler
    </h2>
    <div class="RegSummary">
        <p>
            Editar los plazos de alquiler.</p>
        <ul>
            <li><a href="Precios.aspx">Editar precios</a> </li>
            <li><a href="/Ventas/Precios.aspx">Editar precios de venta</a> </li>
        </ul>
    </div>
    <table class="RegPrecios">
        <tbody>
            <tr>
                <th>
                </th>
                <th>
                    Días
                </th>
            </tr>
            <tr>
                <th>
                    Individual
                </th>
                <td>
                    <asp:TextBox ID="TBIndividual" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Doble y triple
                </th>
                <td>
                    <asp:TextBox ID="TBDobleTriple" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Múltiple (4+ días)
                </th>
                <td>
                    <asp:TextBox ID="TBMúltiple" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="lastRow">
                    <asp:Button runat="server" ID="BActualizar" Text="Actualizar" 
                        onclick="BActualizar_Click" style="height: 26px" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
