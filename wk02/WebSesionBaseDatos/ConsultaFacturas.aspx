<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaFacturas.aspx.cs" Inherits="ConsultaFacturas" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" EnableViewState="true">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <table border="0" cellpadding="1" cellspacing="1">
        <tr>
            <td style="width: 100px; height: 565px;" valign="top">
              
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0 style="width: 301%"><TBODY><TR><TD vAlign=top colSpan=2></TD></TR><TR><TD style="WIDTH: 30%" vAlign=top>Fecha Inicial:</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_fecha_inicial" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 30%" vAlign=top>Fecha Final:</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_fecha_final" runat="server" Width="100px"></asp:TextBox>&nbsp; </TD></TR></TBODY></TABLE><TABLE cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD style="WIDTH: 30%"></TD><TD style="WIDTH: 100px"><asp:Button id="b_consultar" onclick="b_consultar_Click" runat="server" CssClass="botonnuevo" Text="Consultar" __designer:wfdid="w32"></asp:Button></TD></TR><TR><TD colSpan=2><asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w33"><ProgressTemplate>
<TABLE cellSpacing=1 cellPadding=1 border=0><TBODY><TR><TD style="WIDTH: 13%"><asp:Image id="Image1" runat="server" __designer:wfdid="w34" ImageUrl="~/Imagenes/indicator.gif"></asp:Image></TD><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" __designer:wfdid="w35" Width="148px" Text="Consultando..." Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE>
</ProgressTemplate>
</asp:UpdateProgress></TD></TR><TR><TD colSpan=2><asp:GridView id="gv_lista" runat="server" Width="365px" __designer:wfdid="w36" GridLines="None" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="num_factura" HeaderText="Factura Numero"></asp:BoundField>
<asp:BoundField DataField="fecha_factura" HeaderText="Fecha Factura"></asp:BoundField>
<asp:BoundField DataField="total_factura" HeaderText="Total Factura"></asp:BoundField>
</Columns>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
            
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

