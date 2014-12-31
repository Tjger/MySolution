<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItemDetail.ascx.vb" Inherits="HoaQuaVn.ucItemDetail" %>
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

    <div style="height: 200px; width: 200px;border: 1px solid #d3d3d3;margin-bottom:10px;">
       <asp:Image ID="Avatar" Width="200px" Height="200px" runat="server" style="padding: 5px;" />
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
            <td>
                <asp:CheckBox ID="chkHot" Text="Hot" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
         
            <td>
                <asp:Label ID="Label6" runat="server" Text="Price"></asp:Label>
            </td>
           
            <td>
                <asp:Label ID="Label13" runat="server" Text="Xuất Xứ"></asp:Label>
            </td>
            
            <td>
                <asp:Label ID="Label14" runat="server" Text="Unit"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
            </td>
           
            <td>

                <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
            </td>
            
            <td>

                <asp:TextBox ID="txtFromWhere" runat="server"></asp:TextBox>
            </td>
          
            <td>
                <asp:TextBox ID="txtUnitValue" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                <asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DropDownList ID="cboGroup" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng người lớn/100gr/ngày"></asp:Label></td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Vitamin"></asp:Label></td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Năng Lượng"></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtAdultVitamin" runat="server">5.0%</asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtAdultEnergy" runat="server">5.0%</asp:TextBox></td>
            
        </tr>

        <tr>
            <td colspan="2">

                <asp:Label ID="Label10" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng trẻ em/100gr/ngày"></asp:Label>
            </td>
        </tr>

        <tr>
             <td>
                <asp:Label ID="Label11" runat="server" Text="Vitamin"></asp:Label></td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Năng Lượng"></asp:Label></td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="txtChildVitamin" runat="server">5.0%</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtChildEnergy" runat="server">5.0%</asp:TextBox></td>
        </tr>
    </table>
</div>
<br />
<br />
<div>
    <span>Thông tin hàm lượng Vitamin và chất khoáng</span>
    <br />
    <br />
    <div>
        <CKEditor:CKEditorControl ID="txtVitaminElement" BasePath="/ckeditor/" runat="server" Width="726px">
<table border="0" cellpadding="1" cellspacing="1" style="width: 500px;">
	<tbody>
		<tr>
			<td>
				H&agrave;m lượng vitamin</td>
			<td>
				H&agrave;m lượng chất kho&aacute;ng</td>
		</tr>
		<tr>
			<td>
				<ul>
					<li>
						Vitamin A - 76 IU</li>
					<li>
						Vitamin B1 (thiamine) - 0.037mg</li>
					<li>
						Vitamin B2 (riboflavin) - 0.086mg</li>
					<li>
						Niacin - 0.785 mg</li>
					<li>
						Axit Folic - 24 mcg</li>
					<li>
						Axit Pantothenic - 0.394 mg</li>
					<li>
						Vitamin B6 - 0.433 mg</li>
					<li>
						Vitamin C - 10.3 mg</li>
					<li>
						Vitamin E - 0.12 mg</li>
					<li>
						Vitamin K - 0.6 mcg</li>
				</ul>
			</td>
			<td>
				<ul>
					<li>
						Kali - 422 mg</li>
					<li>
						Phốt pho - 26mg</li>
					<li>
						Ma gi&ecirc; - 32mg</li>
					<li>
						Canxi - 6mg</li>
					<li>
						Natri - 1mg</li>
					<li>
						Sắt - 0.31 mg</li>
					<li>
						Selen - 1.2 mcg</li>
					<li>
						Mangan - 0.319mg</li>
					<li>
						Đồng - 0.092 mg</li>
					<li>
						Kẽm - 0.18 mg</li>
				</ul>
			</td>
		</tr>
	</tbody>
</table>

</CKEditor:CKEditorControl>
    </div>

</div>

<div style="margin-top: 18px; margin-left: 276px;">
    <div style=" float: left; ">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>
