<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Tin-Tuc.aspx.vb" Inherits="HoaQuaVn.List_News" %>

<%@ Register Src="~/FrontEnd/UserControl/News/ucNews.ascx" TagPrefix="uc1" TagName="ucNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news-title">Tin Tức</div>
    <div id="powered"></div>
    <div style="height: 1200px; margin-left: 15px;">
        <div class="box-news">
            <asp:DataList ID="dtlComboList" runat="server" RepeatColumns="1">
                <ItemTemplate>

                    <div class="news-row-1">
                        <div class="news-uc-title">
                            <span>
                                <a href="../../News.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "AutoID")%>">
                                    <asp:Label ID="lblNewTitle" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label></a>
                            </span>

                        </div>

                        <div class="news-image-title">
                            <asp:Image ID="NewImage" runat="server" Width="154px" Height="110px" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "Image")%>' />
                        </div>
                        <div class="news-des">
                            <asp:Label ID="lblNewDes" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "SubContent")%>'></asp:Label>

                        </div>
                    </div>

                </ItemTemplate>
            </asp:DataList>

        </div>
    </div>

</asp:Content>
