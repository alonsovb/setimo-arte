<%@ Page Title="Registro de cliente" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebSite.RegistrarClientes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Registrar nuevo socio
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </h2>
    <p>
        &nbsp;</p>
    <div class="RegSummary">
        <p>
            Registrar nuevo socio. Ingrese los datos solicitados a continuación.</p>
        <ul>
            <li><a href="/Alquileres/Registrar.aspx">Registrar alquiler</a></li>
            <li><a href="/Ventas/Registrar.aspx">Registrar venta</a></li>
            <li><a href="/Inventario/Registrar.aspx">Registrar película</a></li>
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
                        <asp:TextBox ID="TBNombre" runat="server" CssClass="RegForm">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Apellidos
                    </td>
                    <td>
                        <asp:TextBox ID="TBApellidos" runat="server" CssClass="RegForm">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fotografía
                    </td>
                    <td>
                        <asp:Image ID="IFotografía" runat="server" />
                        <asp:FileUpload ID="FUFotografía" runat="server" CssClass="RegForm" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Teléfono
                    </td>
                    <td>
                        <asp:TextBox ID="TBTeléfono" runat="server" CssClass="RegForm"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="TBTeléfono_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="TBTeléfono" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="TBEmail" runat="server" CssClass="RegForm"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="TBDirección" runat="server" CssClass="RegForm" Rows="2" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="lastRow">
                        <asp:Button runat="server" ID="BAgregar" Text="Agregar" 
                            onclick="BAgregar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="lastRow">
                        <asp:RegularExpressionValidator ID="REEteléfono" runat="server" 
                            ControlToValidate="TBTeléfono" ErrorMessage="Formato incorrecto del teléfono" 
                            ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="REEmail" runat="server" 
                            ControlToValidate="TBEmail" ErrorMessage="Formato incorrecto del email" 
                            ValidationExpression="[a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
