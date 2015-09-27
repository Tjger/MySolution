<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCombo.ascx.vb" Inherits="HoaQuaVn.ucCombo" %>
<asp:Label ID="Label1" runat="server" Text="Combo List"></asp:Label>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" CssClass="table" AutoGenerateColumns="False"  AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:BoundField DataField="ComboID" HeaderText="ID" />
        <asp:ImageField  DataImageUrlField="ComboImageURL" ControlStyle-Height="30" ControlStyle-Width="30" HeaderText="Image" />
        <asp:BoundField DataField="ComboName" HeaderText="Name" />
        <asp:CheckBoxField DataField="Active" HeaderText="Active" />  
        <asp:BoundField DataField="ComboPrice" HeaderText="Price" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:HyperLinkField DataNavigateUrlFields="ComboID" DataNavigateUrlFormatString="~/Admin.aspx?module=7&m=1&Id={0}" Text="View Detail" />
          <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>
    </Columns>

    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
     <PagerStyle CssClass="gridview" />
</asp:GridView>

<asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="80px" />