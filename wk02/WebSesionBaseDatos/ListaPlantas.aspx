<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaPlantas.aspx.cs" Inherits="ListaPlantas" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="1" cellspacing="1">
        <caption align="center">
            Lista de Plantas</caption>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="gv_lista" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDataBound="gv_lista_RowDataBound" AllowPaging="True" OnPageIndexChanging="gv_lista_PageIndexChanging" PageSize="5" DataKeyNames="Cod_Planta" OnRowCommand="gv_lista_RowCommand">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Planta" HeaderText="Codigo" />
                        <asp:BoundField DataField="nombre_planta" HeaderText="Nombre" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                        <asp:HyperLinkField Text="Editar" DataNavigateUrlFields="cod_planta" DataNavigateUrlFormatString="Datosplanta.aspx?cod={0}" />
                        <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
                    </Columns>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" CssClass="botonnuevo" Text="Nuevo" OnClick="Button1_Click" />
</asp:Content>

