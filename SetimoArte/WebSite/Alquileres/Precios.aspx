<%@ Page Title="Precios de alquiler" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Precios.aspx.cs" Inherits="WebSite.PreciosAlquileres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Precios de alquiler
    </h2>
    <div class="RegSummary">
        <p>
            Editar los precios de alquiler.</p>
        <ul>
            <li><a href="Plazos.aspx">Editar plazos</a> </li>
            <li><a href="/Ventas/Precios.aspx">Editar precios de venta</a> </li>
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
                <th>
                    Blue Ray
                </th>
                <th>
                    HD DVD
                </th>
            </tr>
            <tr>
                <th>
                    Individual
                </th>
                <td>
                    <asp:TextBox ID="TBIndividualDVD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBIndividualBR" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBIndividualHD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Múltiple
                </th>
                <td>
                    <asp:TextBox ID="TBMultipleDVD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBMultipleBR" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBMultipleHD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Adicional
                </th>
                <td>
                    <asp:TextBox ID="TBAdicionalDVD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBAdicionalBR" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TBAdicionalHD" runat="server" CssClass="RegForm"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="lastRow">
                    <asp:Button runat="server" ID="BActualizar" Text="Actualizar" 
                        onclick="BActualizar_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
