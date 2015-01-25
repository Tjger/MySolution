<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucConfig.ascx.vb" Inherits="HoaQuaVn.ucConfig" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript">
    function previewFile1() {
        var preview = document.querySelector('#<%=Image1.ClientID%>');
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

    function previewFile2() {
        var preview = document.querySelector('#<%=Image2.ClientID%>');
        var file = document.querySelector('#<%=FileUpload2.ClientID%>').files[0];
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

    function previewFile3() {
        var preview = document.querySelector('#<%=Image3.ClientID%>');
        var file = document.querySelector('#<%=FileUpload3.ClientID%>').files[0];
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


<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td>
                    <div style="height: 100px; width: 400px;">
                        <asp:Label ID="Label1" runat="server" Text="Image 1 (Rộng : 1920px, Dài 500px)"></asp:Label>
                        <div style="height: 100px; width: 400px; border: 1px solid #d3d3d3; margin-bottom: 10px;">
                            <asp:Image ID="Image1" Width="400px" Height="100px" runat="server" Style="padding: 5px;" />
                        </div>

                        <div>
                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="previewFile1()" />
                        </div>
                    </div>
                </td>




            </tr>


            <tr>
                <td>

                    <div style="height: 100px; width: 400px; margin-top: 75px;">
                        <asp:Label ID="Label6" runat="server" Text="Image 2 (Rộng : 1920px, Dài 500px)"></asp:Label>
                        <div style="height: 100px; width: 400px; border: 1px solid #d3d3d3; margin-bottom: 10px;">
                            <asp:Image ID="Image2" Width="400px" Height="100px" runat="server" Style="padding: 5px;" />
                        </div>

                        <div>
                            <asp:FileUpload ID="FileUpload2" runat="server" onchange="previewFile2()" />
                        </div>
                    </div>
                </td>


            </tr>

            <tr>
                <td>

                    <div style="height: 100px; width: 400px; margin-top: 75px;">
                        <asp:Label ID="Label13" runat="server" Text="Image 3 (Rộng : 1920px, Dài 500px)"></asp:Label>
                        <div style="height: 100px; width: 400px; border: 1px solid #d3d3d3; margin-bottom: 10px;">
                            <asp:Image ID="Image3" Width="400px" Height="100px" runat="server" Style="padding: 5px;" />
                        </div>

                        <div>
                            <asp:FileUpload ID="FileUpload3" runat="server" onchange="previewFile3()" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="item-info-config">
    <div class="item-config">
        <table>
            <tr>
                <td colspan="4">

                    <asp:Label ID="Label2" runat="server" Text="Text 1"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label5" runat="server" Text="Text In Red"></asp:Label>
                </td>
                <td colspan="2">

                    <asp:Label ID="Label7" runat="server" Text="Text In White"></asp:Label>
                </td>


            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtInRed1" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtInWhite1" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label3" runat="server" Text="Text 2"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label8" runat="server" Text="Text In Red"></asp:Label>
                </td>
                <td colspan="2">

                    <asp:Label ID="Label9" runat="server" Text="Text In White"></asp:Label>
                </td>


            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtInRed2" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtInWhite2" runat="server"></asp:TextBox>
                </td>


            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label4" runat="server" Text="Text 3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label10" runat="server" Text="Text In Red"></asp:Label>
                </td>
                <td colspan="2">

                    <asp:Label ID="Label11" runat="server" Text="Text In White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtInRed3" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtInWhite3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBox ID="chkShowRegisterLogo" Text="Show Register Logo" runat="server" Checked="False" />

                </td>
            </tr>
            <tr>
                <td colspan="4">

                    <asp:Label ID="Label16" runat="server" Text="Register Url"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">

                    <asp:TextBox ID="txtRegisterUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label14" runat="server" Text="Email"></asp:Label>
                </td>
                <td colspan="2">

                    <asp:Label ID="Label15" runat="server" Text="Skype"></asp:Label>
                </td>

                <td colspan="2">

                    <asp:Label ID="Label18" runat="server" Text="Yahoo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtEmails" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtSkype" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtYahoo" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2">

                    <asp:Label ID="Label21" runat="server" Text="Facebook Url"></asp:Label>
                </td>
                <td colspan="2">

                    <asp:Label ID="Label22" runat="server" Text="Google+ Url"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtFacebook" runat="server"></asp:TextBox>
                </td>

                <td colspan="2">

                    <asp:TextBox ID="txtGoogle" runat="server"></asp:TextBox>
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

                    <asp:Label ID="Label19" runat="server" Text="Giới Thiệu"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtIntroduce" BasePath="/ckeditor/" runat="server" Width="400px" Height="310px"></CKEditor:CKEditorControl>
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

                    <asp:Label ID="Label12" runat="server" Text="Liên Hệ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtContact" BasePath="/ckeditor/" runat="server" Width="400px" Height="310px"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>
    </div>
</div>

<div style="margin-top: 18px; margin-left: 276px; float: left;">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>
