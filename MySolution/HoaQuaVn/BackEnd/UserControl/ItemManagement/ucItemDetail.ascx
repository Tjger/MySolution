<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItemDetail.ascx.vb" Inherits="HoaQuaVn.ucItemDetail" %>
<style>
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
<asp:CheckBox ID="chkActive" Text="Active" runat="server" />
<asp:CheckBox ID="chkHot" Text="Hot" runat="server" />
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
<br />
<div style="width: 100px; float: left;">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
</div>
<div style="width: 100px;">
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
</div>