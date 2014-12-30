<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCombo.ascx.vb" Inherits="HoaQuaVn.ucCombo" %>

<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" CssClass="table" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="ComboID" HeaderText="ID" />
        <asp:BoundField DataField="ComboName" HeaderText="Name" />
        <asp:CheckBoxField DataField="Active" HeaderText="Active" />  
        <asp:BoundField DataField="ComboPrice" HeaderText="Price" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:HyperLinkField DataNavigateUrlFields="ComboID" DataNavigateUrlFormatString="~/Admin.aspx?module=7&m=1&Id={0}" Text="View Detail" />
    </Columns>

    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
</asp:GridView>

<asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="80px" />