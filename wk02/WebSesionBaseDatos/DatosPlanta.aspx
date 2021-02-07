<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatosPlanta.aspx.cs" Inherits="DatosPlanta" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="1" cellspacing="1" width="100%">
        <caption>
            Información de la Planta</caption>
    <tr>
        <td width="35%">
            Codigo</td>
        <td width="50%">
            <asp:TextBox ID="txt_codigo" runat="server" Width="63px"></asp:TextBox></td>
        <td style="width: 190px">
        </td>
    </tr>
        <tr>
            <td width="35%">
                Nombre:</td>
            <td width="50%">
                <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox></td>
            <td style="width: 190px">
                </td>
        </tr>
        <tr>
            <td width="50%">
                Tipo Planta:</td>
            <td width="50%">
                <asp:DropDownList ID="ddl_tipo" runat="server">
                </asp:DropDownList></td>
            <td style="width: 190px">
            </td>
        </tr>
        <tr>
            <td width="35%">
                Cantidad:</td>
            <td width="50%">
                <asp:TextBox ID="txt_cantidad" runat="server" Width="54px" MaxLength="5"></asp:TextBox></td>
            <td style="width: 190px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 53px">
            </td>
            <td style="width: 103px; height: 53px;">
                <table border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 59px">
                            <asp:Button ID="b_guardar" runat="server" Text="Guardar" Width="76px" CssClass="botonnuevo" OnClick="b_guardar_Click" /></td>
                        <td style="width: 100px">
                            <asp:Button ID="b_cancelar" runat="server" Text="Cancelar" CssClass="botonnuevo" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 190px; height: 53px;">
            </td>
        </tr>
    </table>

</asp:Content>

