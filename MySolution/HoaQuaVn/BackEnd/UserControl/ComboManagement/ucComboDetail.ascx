<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucComboDetail.ascx.vb" Inherits="HoaQuaVn.ucComboDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<script type="text/javascript">
    function previewFile() {
        var preview = document.querySelector('#<%=AvatarC.ClientID%>');
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
        <asp:Image ID="AvatarC" Width="200px" Height="200px" runat="server" Style="padding: 5px;" />
    </div>

    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile()" />
    </div>
</div>

<div class="item-info" style="line-height: 30px; margin-top: 36px;">

    <table>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="chkActive" Text="Active" runat="server" Checked="True" />
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

     <div style="float: left; margin-left: 23px; width: 896px;">
        <asp:Label ID="Label4" runat="server" Text="Giới Thiệu (Max 250 kí tự)"></asp:Label>
        <br />
        <textarea id="txtSubcontent" runat="server" style="width: 709px; height: 103px;" maxlength="250"></textarea>
        <br />
    </div>

    <div style="float: left; margin-left: 23px; width: 896px;">
        <asp:Label ID="Label2" runat="server" Text="Mô Tả"></asp:Label>
        <br />
        <CKEditor:CKEditorControl ID="txtItemList" BasePath="/ckeditor/" runat="server" Width="726px">
       <%--     <table>
	<tbody>
		<tr>
			<td>
				Bưởi da xanh</td>
			<td>
				1,0 -1,2 kg</td>
			<td>
				Bến Tre</td>
		</tr>
		<tr>
			<td>
				Ổi sữa Đ&agrave;i Loan</td>
			<td>
				0,8 -1,2 kg</td>
			<td>
				Tiền Giang</td>
		</tr>
		<tr>
			<td>
				Xo&agrave;i c&aacute;t H&ograve;a Lộc</td>
			<td>
				0,8 -1,2 kg</td>
			<td>
				Xo&agrave;i c&aacute;t H&ograve;a Lộc</td>
		</tr>
		<tr>
			<td>
				Sapoche</td>
			<td>
				1,0 -1,5 kg</td>
			<td>
				Tiền Giang</td>
		</tr>
		<tr>
			<td>
				Cam Khe M&acirc;y</td>
			<td>
				0,8-1,2 kg</td>
			<td>
				H&agrave; Tĩnh</td>
		</tr>
	</tbody>
</table>--%>

        </CKEditor:CKEditorControl>
        <br />
    </div>

   
</div>


<div style="margin-left: 325px; margin-top: 470px;">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div style="float: left;">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>


