<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/FrontEnd/Home.Master" CodeBehind="Detail.aspx.vb" Inherits="HoaQuaVn.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-icon" style="background: none; margin-left: 17px;">THÔNG TIN CHI TIẾT</div>
    <div class="h-combo">
        <div style="width: 826px;">

            <div style="float: left; width: 350px; text-align: center;">
                <img src="FrontEnd/image/combo/c1.png">
            </div>
            <div class="combo-row-1" style="float: right; width: 418px; margin-top: 0px; height: 241px;">

                <div class="combo-1">
                    <span>COMBO 1</span>
                </div>

                <div class="description-detail">
                    <span>Thích hợp cho việc trải nghiệm các loại trái cây tuyệt vời của 3 miền</span>
                </div>
                <div class="combo-details">
                    <table width="500px">
                        <tr>
                            <td>Bưởi da xanh</td>
                            <td>1,0 -1,2 kg</td>
                            <td>Bến Tre</td>


                        </tr>
                        <tr>
                            <td>Ổi sữa Đài Loan</td>
                            <td>0,8 -1,2 kg</td>
                            <td>Tiền Giang</td>


                        </tr>
                        <tr>
                            <td>Xoài cát Hòa Lộc</td>
                            <td>0,8 -1,2 kg</td>
                            <td>Xoài cát Hòa Lộc</td>


                        </tr>
                        <tr>
                            <td>Sapoche</td>
                            <td>1,0 -1,5 kg</td>
                            <td>Tiền Giang</td>


                        </tr>
                        <tr>
                            <td>Cam Khe Mây</td>
                            <td>0,8-1,2 kg</td>
                            <td>Hà Tĩnh</td>


                        </tr>
                    </table>
                </div>


            </div>

        </div>

    </div>

    <div class="guest-title">
        <div><span style="margin-left: 17px;">THÔNG TIN KHÁCH HÀNG </span></div>
        <div class="guest-info">
            <table colspacing="17px" cellpadding="3">
                <tr>
                    <td>Tên</td>
                </tr>
                <tr>

                    <td>
                        <asp:TextBox ID="txtGuestName" runat="server" CssClass="guest-info-box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGuestName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Số điện thoại</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtGuestMobile" runat="server" CssClass="guest-info-box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGuestMobile" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtGuestMail" runat="server" CssClass="guest-info-box"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Message</td>
                </tr>
                <tr>
                    <td>
                        <textarea ID="txtMessage" runat="server" style="width: 550px; height: 95px;"></textarea></td>
                </tr>
            </table>
            <div class="guest-order-action">
                <%--<asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="remodal-cancel" OnClick="btnBack_Click"/>--%>
                <a class="remodal-cancel" href="index.aspx">Quay lại</a>
     <%--           <a class="remodal-confirm" href="#">Đặt hàng</a>--%>
                <asp:Button ID="btnOk" runat="server" Text="Đặt hàng" CssClass="remodal-confirm" OnClick="btnOk_Click"/>
            </div>
        </div>

    </div>
    <div style="float: left;">
        <div style="margin-left: 17px;">SẢN PHẨM CÙNG LOẠI</div>
        <div class="combo-row-1">
            <div class="combo-1">
                <span>COMBO 2</span>
            </div>
            <div class="image-combo">
                <img class="image-padding" src="FrontEnd/image/combo/c11.png" />
            </div>
            <div class="text-description">
                <span>Thích hợp làm quà biếu, trao gửi yêu thương, trao gửi trái cây tuyệt vời</span>
            </div>
            <div class="combo-info">
                <table>
                    <tr>
                        <td>Bưởi da xanh</td>
                        <td>1,0 - 1,2 kg</td>
                        <td>Bến Tre</td>


                    </tr>
                    <tr>
                        <td>Ổi sữa Đài Loan</td>
                        <td>1,0 - 1,6 kg</td>
                        <td>Tiền Giang</td>


                    </tr>
                    <tr>
                        <td>Xoài cát Hòa Lộc</td>
                        <td>1,2 - 1,6 kg</td>
                        <td>Xoài cát Hòa Lộc</td>


                    </tr>
                    <tr>
                        <td>Sapoche</td>
                        <td>1,6 -2,4  kg</td>
                        <td>Tiền Giang</td>


                    </tr>
                    <tr>
                        <td>Cam Khe Mây</td>
                        <td>1,0 - 1,6 kg</td>
                        <td>Hà Tĩnh</td>


                    </tr>
                </table>
            </div>
        <div class="purchase">
            <div style="margin-top: -8px; font-weight: bold;"> <span><a href="../../Detail2.aspx">Chi Tiết</a></span></div>
        </div>
        <div class="combo-price">
            <div class="price-format">
            400.000 VNĐ
            </div>
        </div>
        </div>
        <div class="combo-row-1">
            <div class="combo-1">
                <span>COMBO 3</span>
            </div>
            <div class="image-combo">
                <img class="image-padding" src="FrontEnd/image/combo/c11.png" />
            </div>
            <div class="text-description">
                <span>Chia sẻ những loại trái cây tuyệt vời, chia sẻ yêu thương với đại gia đình</span>
            </div>
            <div class="combo-info">
                <table>
                    <tr>
                        <td>Bưởi da xanh</td>
                        <td>1,0 -1,2 kg</td>
                        <td>Bến Tre</td>


                    </tr>
                    <tr>
                        <td>Ổi sữa Đài Loan</td>
                        <td>1,0 - 1,6 kg</td>
                        <td>Tiền Giang</td>


                    </tr>
                    <tr>
                        <td>Xoài cát Hòa Lộc</td>
                        <td>1,8 - 2,4 kg</td>
                        <td>Xoài cát Hòa Lộc</td>


                    </tr>
                    <tr>
                        <td>Sapoche</td>
                        <td>1,6 -2,4  kg</td>
                        <td>Tiền Giang</td>


                    </tr>
                    <tr>
                        <td>Cam Khe Mây</td>
                        <td>1,0 - 1,6 kg</td>
                        <td>Hà Tĩnh</td>


                    </tr>
                </table>
            </div>
        <div class="purchase">
            <div style="margin-top: -8px; font-weight: bold;"> <span><a href="../../Detail3.aspx">Chi Tiết</a></span></div>
        </div>
        <div class="combo-price">
            <div class="price-format">
           500.000 VNĐ
            </div>
        </div>
        </div>
    </div>
  
</asp:Content>
