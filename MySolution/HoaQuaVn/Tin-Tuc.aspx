<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Tin-Tuc.aspx.vb" Inherits="HoaQuaVn.List_News" %>

<%@ Register Src="~/FrontEnd/UserControl/News/ucNews.ascx" TagPrefix="uc1" TagName="ucNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news-title">Tin Tức</div>
    <div id="powered"></div>
    <div style="margin-left: 15px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lblPrevs" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lbNext" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <div class="box-news">
                    <asp:DataList ID="dtlComboList" runat="server" RepeatColumns="1">
                        <ItemTemplate>

                            <div class="news-row-1">
                                <div class="news-uc-title">
                                    <span>
                                        <a href='<%#Common.Core.GenerateURL(DataBinder.Eval(Container.DataItem, "Title"), DataBinder.Eval(Container.DataItem, "Id"), "/Tin-Tuc/")%>'>
                                            <asp:Label ID="lblNewTitle" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label></a>
                                    </span>

                                </div>

                                <div class="news-image-title">
                                    <asp:Image ID="NewImage" runat="server" Width="154px" Height="110px" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "Image")%>' />
                                </div>
                                <div class="news-des">
                                    <asp:Label ID="lblNewDes" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:DataList>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>



        <div style="float: left; width: 100%; text-align: center; margin-top: 13px;">
            <div class="button btnPrev">
                <asp:LinkButton ID="lblPrevs" runat="server" OnClick="lbPrev_Click"><</asp:LinkButton>
            </div>

            <div class="button btnNext">
                <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">></asp:LinkButton>
            </div>



        </div>


    </div>

</asp:Content>
