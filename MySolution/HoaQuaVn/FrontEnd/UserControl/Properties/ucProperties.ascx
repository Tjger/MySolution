<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProperties.ascx.vb" Inherits="HoaQuaVn.ucProperties" %>
<%@ Register Src="ucProductProperties.ascx" TagName="ucProductProperties" TagPrefix="uc1" %>
<%@ Register Src="../News/ucNews.ascx" TagName="ucNews" TagPrefix="uc2" %>
<%@ Register Src="../ListProduct/ucListProduct.ascx" TagName="ucListProduct" TagPrefix="uc3" %>
<uc3:ucListProduct ID="ucListProduct1" runat="server" />
<div class="combo-option">
    <div class="product-title" style="float: left"></div>
    <div class="product-news" style="margin-right: 228px; float: right;"></div>
    <uc1:ucProductProperties ID="ucProductProperties1" runat="server" />
    <uc2:ucNews ID="ucNews1" runat="server" />
</div>
