﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItem.ascx.vb" Inherits="HoaQuaVn.ucItem" %>
<%--<style>
    input[type="text"], input[type="submit"], select, textarea, Button {
        border: 3px solid #ebe6e2;
        border-radius: 5px;
        display: block;
        font-family: "Lato",Calibri,Arial,sans-serif;
        font-size: 13px;
        font-weight: 400;
        font-weight: 400;
        margin-bottom: 5px;
        padding: 5px;
        transition: all 0.3s ease-out 0s;
        width: 100%;
    }
</style>

<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Width="184px"></asp:TextBox>
<br />

<asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
<asp:DropDownList ID="cboGroup" runat="server" Width="300px">
</asp:DropDownList>
<br />

<asp:Label ID="Label3" runat="server" Text="Image"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server" width="400px"></textarea>
<br />
<asp:CheckBox ID="chkHot" Text="  Bán chạy" runat="server" />
<br />
<div style="width: 100px; float: left;">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
</div>
<div style="width: 100px;">
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
</div>--%>
<div>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="895px" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="ItemPrice" HeaderText="Price" />

            <asp:HyperLinkField DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/Admin.aspx?module=6&Id={0}" Text="View Detail" />
        </Columns>
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
</div>
