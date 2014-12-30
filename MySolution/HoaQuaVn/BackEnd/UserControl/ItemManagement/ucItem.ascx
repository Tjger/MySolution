<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItem.ascx.vb" Inherits="HoaQuaVn.ucItem" %>

<div class="list-item">
    <asp:GridView ID="GridView1" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" AutoGenerateColumns="False">

        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ID" />
            <asp:BoundField DataField="ItemImageURL" HeaderText="ItemImageURL" />
            <asp:BoundField DataField="ItemName" HeaderText="Name" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" />
            <asp:CheckBoxField DataField="Hot" HeaderText="Hot" />
            <asp:BoundField DataField="ItemPrice" HeaderText="Price" />
            <asp:BoundField DataField="FromWhere" HeaderText="Xuất xứ" />
            <asp:BoundField DataField="UnitValue" HeaderText="Đơn Vị" />
            <asp:HyperLinkField DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/Admin.aspx?module=6&Id={0}" Text="View Detail" />
        </Columns>

        <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />

    </asp:GridView>
</div>
