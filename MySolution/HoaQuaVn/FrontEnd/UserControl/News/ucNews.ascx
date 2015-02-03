<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucNews.ascx.vb" Inherits="HoaQuaVn.ucNews" %>
<div class="uc-box-news">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lblPrev" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbNext" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:DataList ID="dtlComboList" runat="server" RepeatColumns="1">
                <ItemTemplate>

                    <div class="uc-news-row-1">
                        <div class="uc-news-uc-title">
                            <span>
                                 <asp:HyperLink ID="hlTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Title")%>' NavigateUrl= '<%#GenerateURL(DataBinder.Eval(Container.DataItem, "Title"))%>'></asp:HyperLink>  
                               
                            </span>
                           
                        </div>

                        <div class="uc-news-image-title">
                            <asp:Image ID="NewImage" runat="server" Width="154px" Height="110px" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "Image")%>' />
                        </div>
                        <div class="uc-news-des">
                            <asp:Label ID="lblNewDes" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label>

                        </div>
                    </div>

                </ItemTemplate>
            </asp:DataList>
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
