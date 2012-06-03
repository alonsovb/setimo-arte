<%@ Page Title="Registrar venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registrar.aspx.cs" Inherits="WebSite.RegistrarVentas" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mask">
    </div>
    <h2>
        Registro de venta
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <div class="RegSummary">
        <p>
            Registrar una nueva venta. Ingrese los datos correspondientes. Si no es un socio,
            puede dejar el campo <strong>Cliente</strong> vacío.</p>
        <ul>
            <li><a href="/Alquileres/Registrar.aspx">Registrar alquiler</a></li>
            <li><a href="/Clientes/Registrar.aspx">Registrar cliente</a></li>
            <li><a href="/Inventario/Registrar.aspx">Registrar película</a></li>
        </ul>
    </div>
    <div id='div1' runat="server"></div>
    <div class="RegDiv">
        <table class="RegTable">
            <tbody>
                <tr>
                    <td>
                        Cliente
                    </td>
                    <td>
                        <asp:TextBox ID="TBCliente" runat="server" placeholder="Número de socio" CssClass="RegForm"> 
                        </asp:TextBox>
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
                Agregar película a venta
            </h3>
            <asp:DropDownList ID="DPelícula" runat="server" CssClass="RegForm">
            </asp:DropDownList>
            <asp:Button runat="server" ID="BAgregarPelícula" Text="Agregar" OnClick="AgregarPelícula" />
        </div>
    </div>
</asp:Content>
