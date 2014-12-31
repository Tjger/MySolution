<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucComboDetail.ascx.vb" Inherits="HoaQuaVn.ucComboDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="item-info">

    <table>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="chkActive" Text="Active" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtItemName" runat="server" Width="184px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtItemPrice" runat="server" Width="184px"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>

<div style="margin-top: 18px;">
    <div style="float:left;" >
        <asp:Label ID="Label6" runat="server" Text="Item List"></asp:Label>
        <br />
        <asp:CheckBoxList ID="chkItemList" runat="server" Width="120px"  style=" border: 1px solid #d3d3d3; border-radius: 5px;padding: 5px;">
        </asp:CheckBoxList>
        <br />
        
    </div>

    <div  style="   float: left;margin-left: 23px;width: 896px;">
        <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
        <br />
        <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server" Width="726px"></CKEditor:CKEditorControl>
        <br />
    </div>
</div>


<div style="margin-left: 325px;margin-top: 470px;">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div >
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>


