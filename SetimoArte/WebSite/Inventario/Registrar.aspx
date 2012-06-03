<%@ Page Title="Registrar película" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebSite.RegistrarInventario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Registro de película
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <div class="RegSummary">
        <p>
            Agregar nueva película al inventario. Seleccione el nombre, género y la cantidad
            de ítems en el inventario para cada formato.</p>
        <ul>
            <li><a href="/Alquileres/Registrar.aspx">Registrar alquiler</a></li>
            <li><a href="/Ventas/Registrar.aspx">Registrar venta</a></li>
            <li><a href="/Clientes/Registrar.aspx">Registrar cliente</a></li>
        </ul>
    </div>
    <div id='div' runat="server"></div>
    <div class="RegDiv">
        <table class="RegTable">
            <tbody>
                <tr>
                    <td>
                        Nombre
                    </td>
                    <td>
                        <asp:TextBox ID="TBNombre" runat="server" placeholder="Nombre" CssClass="RegForm">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Categoría
                    </td>
                    <td>
                        <asp:DropDownList ID="DLCategoría" runat="server" CssClass="RegForm">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        DVD
                    </td>
                    <td>
                        <asp:TextBox ID="TBDVDs" runat="server" placeholder="Cantidad" CssClass="RegForm"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="TBDVDs_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" TargetControlID="TBDVDs" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        BlueRay
                    </td>
                    <td>
                        <asp:TextBox ID="TBBRs" runat="server" placeholder="Cantidad" CssClass="RegForm"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="TBBRs_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" TargetControlID="TBBRs" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        HD DVD
                    </td>
                    <td>
                        <asp:TextBox ID="TBHDDVDs" runat="server" placeholder="Cantidad" CssClass="RegForm"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="TBHDDVDs_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="TBHDDVDs" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="lastRow">
                        <asp:Button runat="server" ID="BAgregar" Text="Agregar" 
                            onclick="BAgregar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
