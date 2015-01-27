<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRole.ascx.vb" Inherits="HoaQuaVn.ucRole" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label17" runat="server" Text="Quy Định Chung"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtRole" BasePath="/ckeditor/" runat="server" Width="400px" Height="310px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="SaveCancel">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>