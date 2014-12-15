<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucPopupDetails.ascx.vb" Inherits="HoaQuaVn.ucPopupDetails" %>
<div class="remodal" data-remodal-id="modal">
    <h1>Thông tin chi tiết Combo 1</h1>
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
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>So dien thoai</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Email</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Ten</td>
                    </tr>
                    <tr>
                        <td>
                            <textarea id="txtMessage" runat="server"></textarea></td>
                    </tr>
                </table>
            </div>

        </div>
        <div class="guest-order-action">
            
            <a class="remodal-cancel" href="#">Hủy</a>
            <asp:Button  ID="btnOk"  Text="Đồng ý"  runat="server" CssClass="remodal-confirm" />
        </div>

    </div>

</div>
