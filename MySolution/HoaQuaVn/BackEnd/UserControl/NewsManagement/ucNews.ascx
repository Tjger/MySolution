﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucNews.ascx.vb" Inherits="HoaQuaVn.ucNews1" %>
<asp:Label ID="Label1" runat="server" Text="News List"></asp:Label>
<asp:GridView ID="GridView1" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">

    <Columns>
        <asp:BoundField DataField="AutoID" HeaderText="ID" />
        <asp:ImageField  DataImageUrlField="Image" ControlStyle-Height="30" ControlStyle-Width="30" HeaderText="Image" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="SubContent" HeaderText="SubContent" />       
        <asp:BoundField DataField="DateInput" HeaderText="Date" />
        <asp:HyperLinkField DataNavigateUrlFields="AutoID" DataNavigateUrlFormatString="~/Admin.aspx?module=8&m=1&Id={0}" Text="View Detail" />
           <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>
    </Columns>

    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
    <PagerStyle CssClass="gridview" />
</asp:GridView>

<asp:Button ID="btnAddNew" runat="server" Text="Add New" Width="80px" />

