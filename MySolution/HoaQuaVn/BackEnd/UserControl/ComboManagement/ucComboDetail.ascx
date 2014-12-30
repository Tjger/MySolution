<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucComboDetail.ascx.vb" Inherits="HoaQuaVn.ucComboDetail" %>
<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:CheckBox ID="chkActive" Text="Active" runat="server" />
<br />
<asp:Label ID="Label5" runat="server" Text="Item Price"></asp:Label>
<asp:TextBox ID="txtItemPrice" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server"></textarea>
<br />
<asp:Label ID="Label6" runat="server" Text="Item List"></asp:Label>
<br />
<asp:CheckBoxList ID="chkItemList" runat="server"  Width="96px">
</asp:CheckBoxList>
<br />
<div style="width: 100px; float: left;">
   <asp:Button ID="btnSave" runat="server" Text="Save" />
</div>
<div style="width: 100px;">
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</div>


