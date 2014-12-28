<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCombo.ascx.vb" Inherits="HoaQuaVn.ucCombo" %>
<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Height="16px" Width="184px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
<asp:DropDownList ID="cboGroup" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Image"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server"></textarea>
<br />
<br />
<asp:Button ID="btnSave" runat="server" Text="Save" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px">
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