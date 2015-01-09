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
<div style="float:left;width:100%;text-align:center;">

    <asp:LinkButton ID="lblPrev" runat="server" OnClick="lbPrev_Click">Trước</asp:LinkButton>        
    <asp:label id="lblShow" runat="server"></asp:label>
    <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">Sau</asp:LinkButton>
   
</div>
