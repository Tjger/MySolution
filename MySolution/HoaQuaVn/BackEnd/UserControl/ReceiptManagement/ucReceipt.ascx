<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucReceipt.ascx.vb" Inherits="HoaQuaVn.ucReceipt" %>

<asp:Calendar ID="ReceiptCalendar" runat="server">
    <TitleStyle BackColor="#428bca" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
</asp:Calendar>
<p>
    <br />
</p>

<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1015px" CssClass="table" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
    <Columns>

        <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
        <asp:BoundField DataField="GuestName" HeaderText="Guest Name" />
        <asp:BoundField DataField="GuestMobile" HeaderText="Mobile" />
        <asp:BoundField DataField="GuestEmail" HeaderText="Email" />
        <asp:BoundField DataField="GuestAddress" HeaderText="Address" />
        <asp:BoundField DataField="Message" HeaderText="Message" />
             <asp:BoundField DataField="StatusView" HeaderText="Status" />
        <asp:HyperLinkField DataNavigateUrlFields="ReceiptNo" DataNavigateUrlFormatString="~/Admin.aspx?module=9&Id={0}" Text="View Detail" />
         <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>
    </Columns>
    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
    <PagerStyle CssClass="gridview" />
</asp:GridView>


