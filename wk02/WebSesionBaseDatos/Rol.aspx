<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rol.aspx.cs" Inherits="Rol" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="1" cellspacing="1">
        <tr>
            <td style="width: 100px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0><TBODY><TR><TD style="WIDTH: 100px" vAlign=top><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"><ProgressTemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0><TBODY><TR><TD style="WIDTH: 13%; HEIGHT: 21px"><asp:Image id="Image1" runat="server" ImageUrl="~/Imagenes/indicator.gif"></asp:Image></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:Label id="Label1" runat="server" Width="146px" Text="Cargando Roles..." Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE>
</ProgressTemplate>
</asp:UpdateProgress></TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:ListBox id="lst_usuarios" runat="server" OnSelectedIndexChanged="lst_usuarios_SelectedIndexChanged" AutoPostBack="True" Height="270px" Width="192px"></asp:ListBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel></td>
            <td style="width: 100px" valign="top">
                <table border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 100px">
                            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                <contenttemplate>
                            <asp:CheckBoxList ID="chkl_roles" runat="server">
                            </asp:CheckBoxList>
</contenttemplate>
                            </asp:UpdatePanel></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0><TBODY><TR><TD style="WIDTH: 100px"><asp:UpdateProgress id="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2"><ProgressTemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0><TBODY><TR><TD style="WIDTH: 13%"><asp:Image id="Image2" runat="server" ImageUrl="~/Imagenes/indicator.gif"></asp:Image></TD><TD style="WIDTH: 100px"><asp:Label id="Label2" runat="server" Font-Bold="True" Text="Actualizando..."></asp:Label></TD></TR></TBODY></TABLE>
</ProgressTemplate>
</asp:UpdateProgress></TD></TR><TR><TD style="WIDTH: 100px"><asp:Button id="b_actualizar" runat="server" Text="Actualizar Roles" CssClass="botonnuevo" OnClick="b_actualizar_Click"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                </td>
        </tr>
    </table>
</asp:Content>

