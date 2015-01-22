<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Item.aspx.vb" Inherits="HoaQuaVn.Item" %>
<%@ Register Src="~/FrontEnd/UserControl/Capcha/ucCapCha.ascx" TagPrefix="uc1" TagName="ucCapCha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-icon" style="background: none; margin-left: 17px;"></div>
    <div class="h-combo">
        <div style="width: 826px;">

            <div style="float: left; width: 350px; text-align: center;">
                <div>
                    <asp:Image ID="ItemImage" runat="server" Width="209px" Height="152px" />
                </div>
              
            </div>

            <div class="combo-row-2" >

                <div class="combo-1">
                    <span>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></span>
                </div>

                <div class="description-detail">
                    <span>
                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></span>
                </div>
                  <div class="price-format" style="color: #83e361;">
                    <span>
                        <asp:Label ID="lblItemPrice" runat="server" Text=""></asp:Label></span>
                </div>
                


            </div>
              <div class="combo-title"><span >Thông Tin Chi Tiết</span></div>
            <div class="combo-details">
                    <asp:Label ID="lblItemList" runat="server" Text=""></asp:Label>
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
                                   <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
            <uc1:ucCapCha runat="server" id="ucCapCha" />
            <%-- End Capcha --%>
            <div class="guest-order-action">
                <%--<asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="remodal-cancel" OnClick="btnBack_Click"/>--%>
                <a class="remodal-cancel" href="index.aspx">Quay lại</a>
                <%--           <a class="remodal-confirm" href="#">Đặt hàng</a>--%>
                <asp:Button ID="btnOk" runat="server" Text="Đặt hàng" CssClass="remodal-confirm" OnClick="btnOk_Click" />
                  <asp:Label ID="lblErrMes" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>

    </div>
    <div style="float: left;">
       <div class="combo-title">SẢN PHẨM CÙNG LOẠI</div>


        <div class="combo-collection">
            <asp:DataList ID="dtlItemRelativeLists" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <div class="box combo-cycle">
                        <div class="imagecombo">
                            <asp:Image ID="NewImageRelative" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
                        </div>
                        <div class="comboname ">
                            <span>
                                <a href="../../Item.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ItemID")%>">
                                    <asp:Label ID="lblItemNameRelative" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>


    </div>
</asp:Content>
