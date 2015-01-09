<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProductProperties.ascx.vb" Inherits="HoaQuaVn.ucProductProperties" %>
<script type="text/javascript">
    $(function () {


        $("#<%= lbNext.ClientID%>").click(function (event) {

            event.preventDefault(); 
            $("#dataItem").load("index.aspx?action=next #dataItem");


        });
        $("#<%= lbPrev.ClientID%>").click(function (event) {

            event.preventDefault(); 
            $("#dataItem").load("index.aspx?action=prev #dataItem");


        });

    });
</script>
<div class="combo-collection" id="dataItem">
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
<div style="float: left; width: 100%; text-align: center;">

    <asp:LinkButton ID="lbPrev" runat="server">Trước</asp:LinkButton>
    <asp:Label ID="lblShow" runat="server"></asp:Label>
    <asp:LinkButton ID="lbNext" runat="server">Sau</asp:LinkButton>

</div>
