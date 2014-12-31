<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucReceipt.ascx.vb" Inherits="HoaQuaVn.ucReceipt" %>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1015px" CssClass="table" AutoGenerateColumns="False">
        <Columns>
        <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
        <asp:BoundField  DataField="GuestName" HeaderText="Guest Name" />
        <asp:BoundField DataField="GuestMobile" HeaderText="Mobile" />
        <asp:BoundField DataField="GuestEmail" HeaderText="Email" />
        <asp:BoundField DataField="GuestAddress" HeaderText="Address" />
        <asp:BoundField DataField="Message" HeaderText="Message" />
<%--        <asp:HyperLinkField DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/Admin.aspx?module=6&m=1&Id={0}" Text="View Detail" />--%>
    </Columns>
     <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
</asp:GridView>

