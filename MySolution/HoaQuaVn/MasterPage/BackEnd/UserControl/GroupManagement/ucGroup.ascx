<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucGroup.ascx.vb" Inherits="HoaQuaVn.ucGroup" %>
<asp:Label ID="Label1" runat="server" Text="Group Name"></asp:Label>
<asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
<asp:Button ID="btnSave" runat="server" Text="Save" />
<br />
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="603px">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
