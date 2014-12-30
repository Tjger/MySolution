<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucNewsDetail.ascx.vb" Inherits="HoaQuaVn.ucNewsDetail" %>
<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Height="16px" Width="184px"></asp:TextBox>
<br />
<asp:CheckBox ID="chkActive" Text="Active" runat="server" />
<br />
<asp:Label ID="Label5" runat="server" Text="Item Price"></asp:Label>
<asp:TextBox ID="txtItemPrice" runat="server" Height="16px" Width="184px"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server"></textarea>
<br />
<asp:Label ID="Label6" runat="server" Text="Item List"></asp:Label>
<br />
<asp:CheckBoxList ID="chkItemList" runat="server" Height="35px" Width="96px">
</asp:CheckBoxList>
<br />
<asp:Button ID="btnSave" runat="server" Text="Save" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />