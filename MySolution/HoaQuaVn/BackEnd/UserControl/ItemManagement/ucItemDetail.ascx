<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItemDetail.ascx.vb" Inherits="HoaQuaVn.ucItemDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<style>
    input[type="text"], input[type="submit"], select,  Button {
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

<asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:Label ID="Label6" runat="server" Text="Price"></asp:Label>
<asp:TextBox ID="txtItemPrice" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:Label ID="Label13" runat="server" Text="Xuất Xứ"></asp:Label>
<asp:TextBox ID="txtFromWhere" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:Label ID="Label14" runat="server" Text="Unit"></asp:Label>
<asp:TextBox ID="txtUnitValue" runat="server" Width="184px"></asp:TextBox>
<br />
<asp:CheckBox ID="chkActive" Text="Active" runat="server" Checked="True" />
<asp:CheckBox ID="chkHot" Text="Hot" runat="server" />
<br />

<asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
<asp:DropDownList ID="cboGroup" runat="server" Width="300px">
</asp:DropDownList>
<br />

<asp:Label ID="Label3" runat="server" Text="Image"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="Label7" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng người lớn/100gr/ngày"></asp:Label>
<br />
<asp:Label ID="Label8" runat="server" Text="Vitamin"></asp:Label>
<br />
<asp:TextBox ID="txtAdultVitamin" runat="server" Width="184px">5.0%</asp:TextBox>
<br />
<br />
<asp:Label ID="Label9" runat="server" Text="Năng Lượng"></asp:Label>
<br />
<asp:TextBox ID="txtAdultEnergy" runat="server" Width="184px">5.0%</asp:TextBox>
<br />

<asp:Label ID="Label10" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng trẻ em/100gr/ngày"></asp:Label>
<br />
<asp:Label ID="Label11" runat="server" Text="Vitamin"></asp:Label>
<br />
<asp:TextBox ID="txtChildVitamin" runat="server" Width="184px">5.0%</asp:TextBox>
<br />

<asp:Label ID="Label12" runat="server" Text="Năng Lượng"></asp:Label>
<br />
<asp:TextBox ID="txtChildEnergy" runat="server" Width="184px">5.0%</asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />

<CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
<br />

<asp:Label ID="Label5" runat="server" Text="Thông tin hàm lượng Vitamin và chất khoáng"></asp:Label>
<br />
<CKEditor:CKEditorControl ID="txtVitaminElement" BasePath="/ckeditor/" runat="server">
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
<p>
	&nbsp;</p>
  
</CKEditor:CKEditorControl>
<br />
<br />
<div style="width: 100px; float: left;">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
</div>
<div style="width: 100px;">
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
</div>
