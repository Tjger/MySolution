<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/FrontEnd/Home.Master" CodeBehind="Combo.aspx.vb" Inherits="HoaQuaVn.Combo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-icon" style="background: none; margin-left: 17px;"></div>
    <div class="h-combo">
        <div style="width: 826px;">

            <div style="float: left; width: 350px; text-align: center;">
                <div>
                    <img src="FrontEnd/image/combo/c1.png">
                </div>

            </div>

            <div class="combo-row-2">

                <div class="combo-1">
                    <span>
                        <asp:Label ID="lblComboName" runat="server" Text="Label"></asp:Label></span>
                </div>

                <div class="description-detail">
                    <span>
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></span>
                </div>

                <div class="price-format" style="color: #83e361;">
                    <span>
                        <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></span>
                </div>




            </div>
             <div class="combo-title"><span >Thông Tin Chi Tiết</span></div>
            <div class="combo-details">
                <asp:Label ID="lblItemList" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

    </div>

    <div class="guest-title">
        <div class="combo-title"><span>THÔNG TIN KHÁCH HÀNG </span></div>
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
    <div class="item-relative">
        <div class="combo-title">SẢN PHẨM CÙNG LOẠI</div>

        <asp:DataList ID="dtlComboRelateList" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <div class="combo-row-1">
                    <div class="combo-1">
                        <span>
                            <asp:Label ID="lblComboRelativeName" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ComboName")%>'>

                            </asp:Label></span>
                    </div>
                    <div class="image-combo">
                        <img class="image-padding" src="FrontEnd/image/combo/c11.png" />
                    </div>
                    <div class="text-description">
                        <span>
                            <asp:Label ID="lblComboRelativeDescription" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label></span>
                    </div>
                    <div class="combo-info">
                        <asp:Label ID="lblComboRelativeItemList" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemList")%>'></asp:Label>
                    </div>
                    <div class="purchase">
                        <div style="margin-top: -8px; font-weight: bold;"><span><a href="../../Combo.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ComboID")%>">Chi Tiết</a></span></div>
                    </div>
                    <div class="combo-price">
                        <div class="price-format">
                            <asp:Label ID="lblComboRelativePrice" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ComboPrice")%>'></asp:Label>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

    </div>

</asp:Content>
