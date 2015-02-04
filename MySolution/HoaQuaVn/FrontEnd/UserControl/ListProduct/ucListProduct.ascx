<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucListProduct.ascx.vb" Inherits="HoaQuaVn.ucListProduct" %>
<div class="product-icon"></div>
 <div class="h-combo">
<asp:DataList ID="dtlComboList" runat="server" RepeatColumns="3" >
    <ItemTemplate>
       

            <div class="combo-row-1">
                <div class="combo-1">
                    <span>
                        <asp:Label ID="lblComboName" runat="server"  Text=' <%# DataBinder.Eval(Container.DataItem, "ComboName")%>'>

                        </asp:Label></span>
                </div>
                <div class="image-combo">
                    <asp:Image ID="NewImage" CssClass="image-padding" Width="108px" Height="80px" runat="server" ImageUrl=' <%# DataBinder.Eval(Container.DataItem, "ComboImageURL")%>' />
                    
                    
                </div>
                <div class="text-description">
                    <span>
                        <asp:Label ID="lblDescription" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label></span>
                </div>
<%--                <div class="combo-info">
                    <asp:Label ID="lblItemList" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ItemList")%>'></asp:Label>
                    
                </div>--%>
                <div class="purchase">
                    <div style="margin-top: -8px; font-weight: bold;"><span><a href='<%#Common.Core.GenerateURL(DataBinder.Eval(Container.DataItem, "ComboName"), DataBinder.Eval(Container.DataItem, "ComboID"), "/combo/")%>'>Chi Tiết</a></span></div>
                </div>
                <div class="combo-price">
                    <div class="price-format">
                        <asp:Label ID="lblPrice" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "ComboPrice")%>'></asp:Label>
                    </div>
                </div>
            </div>


       
    </ItemTemplate>
</asp:DataList>
      </div>