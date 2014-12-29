<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucGroup.ascx.vb" Inherits="HoaQuaVn.ucGroup" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="PageTitle">
    Nhóm Sản Phẩm
</asp:Content>
<asp:Label ID="Label1" runat="server" Text="Group Name"></asp:Label>
<asp:TextBox ID="txtGroupNameNew" runat="server"></asp:TextBox>
<asp:Button ID="btnSave" runat="server" Text="Save" />
<br />
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="603px" AutoGenerateColumns="False" AllowPaging="True"   OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"  OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" CssClass="table">
    <Columns>
        <asp:BoundField DataField="GroupID" HeaderText="ID" ItemStyle-Width="40" ReadOnly="true" />
        <asp:TemplateField HeaderText="Name" ItemStyle-Width="90">
            <EditItemTemplate>
                <asp:TextBox ID="txtGroupName" runat="server" Text='<%# Bind("GroupName")%>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton ="true" ItemStyle-Width="60" />
        <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="60"/>

    </Columns>
    <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
</asp:GridView>
