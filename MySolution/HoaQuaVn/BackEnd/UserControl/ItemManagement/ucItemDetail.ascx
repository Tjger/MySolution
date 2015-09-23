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
            <td>
                <asp:CheckBox ID="chkHot" Text="Hot" runat="server" /></td>
            <%--<td>
                <asp:CheckBox ID="chkShow" Text="ShowInHomePage" runat="server" /></td>--%>
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
                <asp:Label ID="Label14" runat="server" Text="Key Search"></asp:Label>
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
       
    </table>
</div>

<div style="margin-top: 18px;">

    <div style="float: left; width: 896px;">
        <asp:Label ID="Label4" runat="server" Text="Giới Thiệu (Max 250 kí tự)"></asp:Label>
        <br />
        <textarea id="txtDescription" runat="server" style="width: 709px; height: 103px;" maxlength="250"></textarea>
        <br />
    </div>

    <div style="float: left; width: 896px;">
        <span>Mô Tả</span>
        <br />
        <div>
            <CKEditor:CKEditorControl ID="txtVitaminElement" BasePath="/ckeditor/" runat="server" Width="726px">
           
</CKEditor:CKEditorControl>
        </div>

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
