<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucNewsDetail.ascx.vb" Inherits="HoaQuaVn.ucNewsDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript">
    function previewFile() {
        var preview = document.querySelector('#<%=Avatar.ClientID %>');
        var file = document.querySelector('#<%=FileUpload1.ClientID%>').files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.src = reader.result;
        }

        if (file) {
            reader.readAsDataURL(file);
        } else {
            preview.src = "";
        }
    }
    </script>

<div style="height: 200px; width: 200px;">

    <div style="height: 200px; width: 200px; border: 1px solid #d3d3d3; margin-bottom: 10px;">
        <asp:Image ID="Avatar" Width="200px" Height="200px" runat="server" Style="padding: 5px;" />
    </div>

    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" />
    </div>
</div>
<div style="line-height: 30px; margin-top: 36px;" class="item-info">

    <table>
        <tr>
            <td>
                <asp:CheckBox ID="chkActive" Text="Active" runat="server" Checked="True" /></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Title (Max 250 kí tự)"></asp:Label>
            </td>


        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="250"></asp:TextBox>
            </td>


        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Mô Tả (Max 250 kí tự)"></asp:Label></td>

        </tr>
        <tr>
            <td colspan="2">
                <textarea ID="txtSubcontent" runat="server" style="width: 709px; height: 103px;" maxlength="250"></textarea>
            </td>


        </tr>

    </table>
</div>
<br />
<div>
    <span>Nội Dung</span>
    <br />
    <div>
        <CKEditor:CKEditorControl ID="txtMaincontent" BasePath="/ckeditor/" runat="server" Width="990px"></CKEditor:CKEditorControl>
    </div>

</div>

<div style="margin-top: 18px; margin-left: 276px;">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>
