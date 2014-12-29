<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucComboDetail.ascx.vb" Inherits="HoaQuaVn.ucComboDetail" %>
<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Height="16px" Width="184px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
<asp:DropDownList ID="cboGroup" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Image"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server"></textarea>
<br />
<br />
<asp:Button ID="btnSave" runat="server" Text="Save" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />