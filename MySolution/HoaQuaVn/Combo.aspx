<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Combo.aspx.vb" Inherits="HoaQuaVn.Combo" %>

<%@ Register Src="~/FrontEnd/UserControl/Capcha/ucCapCha.ascx" TagPrefix="uc1" TagName="ucCapCha" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="h-combo" style="background: none; margin-top: 10px;">
        <div style="width: 826px;">

            <div style="float: left; width: 350px; text-align: center;height: 225px;">
                <div>
                    <asp:Image ID="ItemImage" runat="server" Width="209px" Height="225px" />
                </div>

            </div>

            <div class="combo-row-2">

                <div class="combo-2">
                    <span>
                        <asp:Label ID="lblComboName" runat="server" Text="Label"></asp:Label></span>
                </div>

              

                <div class="description-detail">
                    <span>
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></span>
                </div>

                  <div class="price-format2" >
                    <span>
                        <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></span>
                </div>




            </div>
            <div class="combo-title"><span>Thông Tin Chi Tiết</span></div>
            <div class="combo-details">
                <asp:Label ID="lblItemList" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnOk" EventName="Click" />
        </Triggers>
        <ContentTemplate>
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
                                <asp:Label ID="Label1" runat="server" BackColor="White" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Số điện thoại</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtGuestMobile" runat="server" CssClass="guest-info-box"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                            <td>Address</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtGuestAddress" runat="server" CssClass="guest-info-box"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Message</td>
                        </tr>
                        <tr>
                            <td>
                                <textarea id="txtMessage" runat="server" style="width: 550px; height: 95px;"></textarea></td>
                        </tr>

                    </table>
                    <%-- Capcha --%>
                    <uc1:ucCapCha runat="server" ID="ucCapCha" />
                    <%-- End Capcha --%>

                    <div class="guest-order-action">
                        <a class="remodal-cancel" href="index.aspx">Quay lại</a>
                        <asp:Button ID="btnOk" runat="server" Text="Đặt hàng" CssClass="remodal-confirm" OnClick="btnOk_Click" />
                        <asp:Label ID="lblErrMes" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


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
                        <asp:Image ID="NewImage" CssClass="image-padding" Width="108px" Height="80px" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ComboImageURL")%>' />
                    </div>
                    <div class="text-description">
                        <span>
                            <asp:Label ID="lblComboRelativeDescription" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label></span>
                    </div>
                    <%-- <div class="combo-info">
                        <asp:Label ID="lblComboRelativeItemList" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemList")%>'></asp:Label>
                    </div>--%>
                    <div class="purchase">
                        <div style="margin-top: -8px; font-weight: bold;"><span><a href='<%#Common.Core.GenerateURL(DataBinder.Eval(Container.DataItem, "ComboName"), DataBinder.Eval(Container.DataItem, "ComboID"), "/sanpham/")%>'>Chi Tiết</a></span></div>
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
