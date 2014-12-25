<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucGroup.ascx.vb" Inherits="HoaQuaVn.ucGroup" %>
<asp:Label ID="Label1" runat="server" Text="Group Name"></asp:Label>
<asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
<asp:Button ID="btnSave" runat="server" Text="Save" />
<br />
<br />
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="603px" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("GroupName") %>'>
                </asp:Label>
            
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txtGroupID" runat="server" Text='<%# Eval("GroupID") %>'></asp:TextBox>
            </FooterTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtGroupName" Width="60px" runat="server" Text='<%# Eval("GroupName")%>'>

                </asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<% Eval(GroupID) %>' OnClientClick="return confirm('Do you want to delete?')" Text="Delete" OnClick="DeleteGroup">

                </asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Button ID="btnAddNew" runat="server" Text="Add" OnClick="AddNewGroup" />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="true" />
    </Columns>
</asp:GridView>
