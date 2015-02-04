<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProductProperties.ascx.vb" Inherits="HoaQuaVn.ucProductProperties" %>

<div class="combo-collection" id="dataItem">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lblPrev" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbNext" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:DataList ID="dtlItemList" runat="server" RepeatColumns="2">
                <ItemTemplate>
                    <div class="box combo-cycle">
                        <div class="imagecombo">
                            <asp:Image ID="NewImage" Width="168px" Height="128px" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
                        </div>
                        <div class="comboname ">
                            <span>
                                <a href='<%#Common.Core.GenerateURL(DataBinder.Eval(Container.DataItem, "ItemName"), DataBinder.Eval(Container.DataItem, "ItemID"), "/San-Pham/")%>'>
                                    <asp:Label ID="lblItemName" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </ContentTemplate>
    </asp:UpdatePanel>



    <div style="float: left; width: 100%; text-align: center;">
        <div class="button btnPrev" >
            <asp:LinkButton ID="lblPrev" runat="server" OnClick="lbPrev_Click"><</asp:LinkButton>
        </div>

        <div  class="button btnNext" >
            <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">></asp:LinkButton>
        </div>



    </div>
</div>

