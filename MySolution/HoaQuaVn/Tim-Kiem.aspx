<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Tim-Kiem.aspx.vb" Inherits="HoaQuaVn.Tim_Kiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news-title">Kết Quả Tìm Kiếm</div>
    <div id="powered"></div>
    <div style="margin-left: 15px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lblPrev" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lbNext" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <div class="box-news">
                    <asp:DataList ID="dtlItemList" runat="server" RepeatColumns="1">
                        <ItemTemplate>

                            <div class="news-row-1">
                                <div class="news-uc-title">
                                    <span>
                                        <a href="../../Item.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ItemID")%>">
                                            <asp:Label ID="lblNewTitle" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a>
                                    </span>

                                </div>

                                <div class="news-image-title">
                                    <asp:Image ID="NewImage" runat="server" Width="154px" Height="110px" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
                                </div>
                                <div class="news-des">
                                    <asp:Label ID="lblNewDes" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:DataList>

                </div>

                <%--<asp:DataList ID="dtlItemList" runat="server" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="box combo-cycle">
                            <div class="imagecombo">
                                <asp:Image ID="NewImage" Width="168px" Height="128px" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
                            </div>
                            <div class="comboname ">
                                <span>
                                    <a href="../../Item.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ItemID")%>">
                                        <asp:Label ID="lblItemName" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>--%>
            </ContentTemplate>
        </asp:UpdatePanel>



        <div style="float: left; width: 100%; text-align: center; margin-top: 13px;">
            <div class="button btnPrev">
                <asp:LinkButton ID="lblPrev" runat="server" OnClick="lbPrev_Click"><</asp:LinkButton>
            </div>

            <div class="button btnNext">
                <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">></asp:LinkButton>
            </div>



        </div>
    </div>
</asp:Content>
