<%@ Page Title="Registrar alquiler" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebSite.RegistrarAlquileres" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mask">
    </div>
    <h2>
        Registro de alquiler
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <div class="RegSummary">
        <p>
            Registrar nuevo alquiler.</p>
        <ul>
            <li><a href="/Ventas/Registrar.aspx">Registrar venta</a></li>
            <li><a href="/Clientes/Registrar.aspx">Registrar cliente</a></li>
            <li><a href="/Inventario/Registrar.aspx">Registrar película</a></li>
        </ul>
    </div>
    <div class="RegDiv">
        <table class="RegTable">
            <tbody>
                <tr>
                    <td>
                        Cliente
                    </td>
                    <td>
                        <asp:TextBox ID="TBCliente" runat="server" placeholder="Número de socio" CssClass="RegForm"> </asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="TBCliente_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="TBCliente" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Películas
                    </td>
                    <td>
                        <a href="#dialog" name="modal">Agregar película</a>
                        <asp:ListBox ID="LBLista" runat="server" CssClass="RegForm"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Costo total
                    </td>
                    <td>
                        <asp:TextBox ID="TBCosto" runat="server" CssClass="RegForm" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha límite de devolución
                    </td>
                    <td>
                        <asp:TextBox ID="TBDevolución" runat="server" CssClass="RegForm" 
                            Enabled="False"></asp:TextBox>
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
    <div id='div' runat="server"></div>
    <div id="boxes">
        <div id="dialog" class="window">
            <h3>
                Agregar película al alquiler
            </h3>
            <asp:DropDownList ID="DPelícula" runat="server" CssClass="RegForm">
            </asp:DropDownList>
            <asp:DropDownList ID="DFormato" runat="server" CssClass="RegForm">
                <asp:ListItem Text="DVD" Value="0"></asp:ListItem>
                <asp:ListItem Text="Blue Ray" Value="1"></asp:ListItem>
                <asp:ListItem Text="HD DVD" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" ID="BAgregarPelícula" Text="Agregar" OnClick="AgregarPelícula" />
        </div>
    </div>
</asp:Content>
