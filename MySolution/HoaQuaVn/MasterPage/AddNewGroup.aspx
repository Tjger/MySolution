<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/BackEnd/AdminPage.Master" CodeBehind="AddNewGroup.aspx.vb" Inherits="HoaQuaVn.AddNewGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Add New Group
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Group Name"></asp:Label>
    <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</asp:Content>
