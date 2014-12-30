<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucComboDetail.ascx.vb" Inherits="HoaQuaVn.ucComboDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
<CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
<br />
<asp:Label ID="Label6" runat="server" Text="Item List"></asp:Label>
<br />
<asp:CheckBoxList ID="chkItemList" runat="server"  Width="120px">
</asp:CheckBoxList>
<br />
<div style="margin-top:18px;">
    <div style="width: 100px; float: left;width:50%;">
        <div style="float:right;margin-right:7px;">
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
            </div>
    </div>
    <div style="width: 100px;width:50%;">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>


