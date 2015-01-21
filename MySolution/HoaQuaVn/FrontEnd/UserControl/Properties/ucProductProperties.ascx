<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProductProperties.ascx.vb" Inherits="HoaQuaVn.ucProductProperties" %>

<%--<script type="text/javascript">
    $(function () {


        $("#<%= lbNext.ClientID%>").click(function (event) {

            event.preventDefault();
            $("#dataItem").load("index.aspx?action=next #dataItem");


        });

        $("#<%= lblPrev.ClientID%>").click(function (event) {

            event.preventDefault();
            $("#dataItem").load("index.aspx?action=prev #dataItem");


        });
            

    });
</script>--%>
<div class="combo-collection" id="dataItem">

    <asp:DataList ID="dtlItemList" runat="server" RepeatColumns="2">
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
    </asp:DataList>


    <div style="float: left; width: 100%; text-align: center;">

        <asp:LinkButton ID="lblPrev" runat="server" OnClick="lbPrev_Click"><<</asp:LinkButton>

        <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">>></asp:LinkButton>

    </div>
</div>

