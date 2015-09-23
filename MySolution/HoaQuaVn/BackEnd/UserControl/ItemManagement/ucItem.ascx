<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItem.ascx.vb" Inherits="HoaQuaVn.ucItem" %>
<asp:Label ID="Label1" runat="server" Text="Item List"></asp:Label>
<asp:GridView ID="GridView1" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">

    <Columns>
        <asp:BoundField DataField="ItemID" HeaderText="ID" />
        <asp:ImageField  DataImageUrlField="ItemImageURL" ControlStyle-Height="30" ControlStyle-Width="30" HeaderText="Image" />
        <asp:BoundField DataField="ItemName" HeaderText="Name" />
        <asp:CheckBoxField DataField="Active" HeaderText="Active" />
        <asp:CheckBoxField DataField="Hot" HeaderText="Hot" />
        <asp:BoundField DataField="ItemPrice" HeaderText="Price" />
        <asp:BoundField DataField="FromWhere" HeaderText="Xuất xứ" />
        <asp:BoundField DataField="UnitValue" HeaderText="Key Search" />
        <asp:HyperLinkField DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/Admin.aspx?module=6&m=1&Id={0}" Text="View Detail" />
          <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>
    </Columns>

    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
    <PagerStyle CssClass="gridview" />
</asp:GridView>

<asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="80px" />