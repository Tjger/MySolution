<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucProperties.ascx.vb" Inherits="HoaQuaVn.ucProperties" %>
<%@ Register Src="ucProductProperties.ascx" TagName="ucProductProperties" TagPrefix="uc1" %>
<%@ Register Src="../News/ucNews.ascx" TagName="ucNews" TagPrefix="uc2" %>
<%@ Register src="../ListProduct/ucListProduct.ascx" tagname="ucListProduct" tagprefix="uc3" %>
<uc3:ucListProduct ID="ucListProduct1" runat="server" />
<div class="combo-option">
    <div class="product-title" style="float: left"></div>
   

    <uc1:ucProductProperties ID="ucProductProperties1" runat="server" />
    <uc2:ucNews ID="ucNews1" runat="server" />
</div>
