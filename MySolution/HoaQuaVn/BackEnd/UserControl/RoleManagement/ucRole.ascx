<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRole.ascx.vb" Inherits="HoaQuaVn.ucRole" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label12" runat="server" Text="Chính Sách Đổi Trả Hàng"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtTraHang" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label1" runat="server" Text="Hướng Dẫn Mua Hàng"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtMuaHang" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label2" runat="server" Text="Phương Thức Thanh Toán"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtThanhToan" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label3" runat="server" Text="Phương Thức Vận Chuyển"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtVanChuyen" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label4" runat="server" Text="Chính Sách Bảo Mật Thông Tin"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtBaoMat" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label5" runat="server" Text="Chính Sách Bảo Hành"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtBaoHanh" BasePath="/ckeditor/" runat="server" Width="700px" Height="580px"></CKEditor:CKEditorControl>
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