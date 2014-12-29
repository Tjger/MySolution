﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucSEO.ascx.vb" Inherits="HoaQuaVn.ucSEO" %>
<asp:Label ID="Label1" runat="server" Text="SEO"></asp:Label>
<asp:TextBox ID="txtSEONew" runat="server"></asp:TextBox>
<asp:Button ID="btnSave" runat="server" Text="Save" />
<br />
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="603px" AutoGenerateColumns="False" AllowPaging="True"   OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"  OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
    <Columns>
        <asp:BoundField DataField="SeoID" HeaderText="ID" ItemStyle-Width="40" ReadOnly="true" />
        <asp:TemplateField HeaderText="Name" ItemStyle-Width="90">
            <EditItemTemplate>
                <asp:TextBox ID="txtSEO" runat="server" Text='<%# Bind("SEO")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblSEO" runat="server" Text='<%# Bind("SEO")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton ="true" ItemStyle-Width="60" />
        <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>

    </Columns>
</asp:GridView>
