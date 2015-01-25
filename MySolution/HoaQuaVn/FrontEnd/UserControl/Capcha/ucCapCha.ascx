<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCapCha.ascx.vb" Inherits="HoaQuaVn.ucCapCha" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnTryNewWords" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <table>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Image ID="ImgCaptcha" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="LblMsg" runat="server" Text="Nhập mã bảo vệ:"></asp:Label>


                </td>
                <td>
                    <asp:TextBox ID="TxtCpatcha" runat="server" Text=""></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" valign="middle">
                    <asp:LinkButton ID="btnTryNewWords" runat="server" Font-Names="Tahoma"
                        Font-Size="Smaller" OnClick="btnTryNewWords_Click">Lấy mã bảo vệ khác</asp:LinkButton>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>

