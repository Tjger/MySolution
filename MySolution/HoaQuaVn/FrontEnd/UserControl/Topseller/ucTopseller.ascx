<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucTopseller.ascx.vb" Inherits="HoaQuaVn.ucTopseller" %>
<asp:DataList ID="dtlHotItemList" runat="server" RepeatColumns="1">
    <ItemTemplate>
        <div class="product1">
            <asp:Image ID="NewImage" runat="server" Width="110px" Height="93px" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
            <div class="powered1 bestseller">Hot</div>
            <div class="best-title-text">
                <span>
                    <a href="../../Item.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ItemID")%>">
                        <asp:Label ID="lblItemName" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a>
                </span>

            </div>
            <div class="best-price-text"><span><asp:Label ID="lblItemPrice" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemPrice")%>'></asp:Label></span></div>
        </div>

    </ItemTemplate>
</asp:DataList>



