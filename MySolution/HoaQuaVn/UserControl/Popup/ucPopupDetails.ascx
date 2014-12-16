<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucPopupDetails.ascx.vb" Inherits="HoaQuaVn.ucPopupDetails" %>
<div class="remodal" data-remodal-id="modal">
    <h1>Thông tin đặt hàng</h1>
    <div class="guest-order-detail-combo">
        <div class="guest-order-info">


            <div style="width: 250px; float: left;">
                <img src="image/combo/c1.png" />
            </div>
            <div style="float: left; width: 370px; text-align: left;">
                <table colspacing="4" cellpadding="3">
                    <tr>
                        <td>Ten</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtGuestName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGuestName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>So dien thoai</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtGuestMobile" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGuestMobile" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtGuestMail" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Message<asp:Button ID="Button1" runat="server" Text="Button" CausesValidation="false"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <textarea id="txtGuestMes" runat="server"></textarea></td>
                    </tr>
                </table>
            </div>

        </div>
        <div class="guest-order-action">

            <a class="remodal-cancel" href="#">Hủy</a>
            <asp:Button ID="btnOk" Text="Đồng ý" runat="server" OnClick="btnOk_Click" />
        </div>

    </div>

</div>
