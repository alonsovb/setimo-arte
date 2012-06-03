<%@ Page Title="Buscar cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Buscar.aspx.cs" Inherits="WebSite.BuscarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Buscar clientes
    </h2>
    <div class="BuscDiv">
        <p>
            Seleccione el código o el nombre del cliente a buscar.</p>
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
                        <asp:Button runat="server" ID="BBuscar" Text="Buscar" onclick="BBuscar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <ul>
            <li><a href="/Inventario/Buscar.aspx">Buscar película</a> </li>
        </ul>
    </div>
    <div class="ResDiv">
        <asp:Label ID="LBuscar" runat="server" Text="" CssClass="RegForm"></asp:Label>
        <asp:GridView ID="GVLista" runat="server" AutoGenerateColumns="False" 
            CssClass="Gridview">
            <Columns>
                <asp:BoundField DataField="numero_socios" HeaderText="Código" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataFormatString="direccion" HeaderText="Dirección" />
                
            </Columns>
        </asp:GridView>
        <asp:Image ID="IFotografía" runat="server" ImageUrl="/Avatar.png" CssClass="profilePicture"/>
    </div>
</asp:Content>
