﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/FrontEnd/Home.Master" CodeBehind="Item.aspx.vb" Inherits="HoaQuaVn.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-icon" style="background: none; margin-left: 17px;">THÔNG TIN CHI TIẾT</div>
    <div class="h-combo">
        <div style="width: 826px;">

            <div style="float: left; width: 350px; text-align: center;">
                <div>
                    <asp:Image ID="ItemImage" runat="server" Width="209px" Height="152px"/>
                </div>
                <div class="price-format" style="color:#83e361;">
                    <span>
                        <asp:Label ID="lblItemPrice" runat="server" Text=""></asp:Label></span>
                </div>
            </div>

            <div class="combo-row-1" style="float: right; width: 418px; margin-top: 0px; height: 241px;">

                <div class="combo-1">
                    <span>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></span>
                </div>

                <div class="description-detail">
                    <span>
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></span>
                </div>
                <div class="combo-details">
                    <asp:Label ID="lblItemList" runat="server" Text=""></asp:Label>
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
                        <textarea id="txtMessage" runat="server" style="width: 550px; height: 95px;"></textarea></td>
                </tr>
            </table>
            <div class="guest-order-action">
                <%--<asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="remodal-cancel" OnClick="btnBack_Click"/>--%>
                <a class="remodal-cancel" href="index.aspx">Quay lại</a>
                <%--           <a class="remodal-confirm" href="#">Đặt hàng</a>--%>
                <asp:Button ID="btnOk" runat="server" Text="Đặt hàng" CssClass="remodal-confirm" OnClick="btnOk_Click" />
            </div>
        </div>

    </div>
    <div style="float: left;">
        <div style="margin-left: 17px;">SẢN PHẨM CÙNG LOẠI</div>

    </div>
</asp:Content>