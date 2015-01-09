<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProductProperties.ascx.vb" Inherits="HoaQuaVn.ucProductProperties" %>
<div class="combo-collection">
    <asp:DataList ID="dtlItemList" runat="server" RepeatColumns="4">
        <ItemTemplate>
            <div class="box combo-cycle">
                <div class="imagecombo">
                    <asp:Image ID="NewImage" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ItemImageURL")%>' />
                </div>
                <div class="comboname ">
                    <span>
                        <a href="../../Item.aspx?action=view&id=<%# DataBinder.Eval(Container.DataItem, "ItemID")%>">
                            <asp:Label ID="lblItemName" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label></a></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
