<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucNews.ascx.vb" Inherits="HoaQuaVn.ucNews" %>
<div class="box-news">
    <asp:DataList ID="dtlComboList" runat="server" RepeatColumns="1">
        <ItemTemplate>

            <div class="news-row-1">
                <div style="float: left; width: 305px;">
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
