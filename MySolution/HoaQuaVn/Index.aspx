﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Index.aspx.vb" Inherits="HoaQuaVn.Index1" %>

<%@ Register Src="~/FrontEnd/UserControl/ListProduct/ucListProduct.ascx" TagPrefix="uc1" TagName="ucListProduct" %>
<%@ Register Src="~/FrontEnd/UserControl/Properties/ucProductProperties.ascx" TagPrefix="uc1" TagName="ucProductProperties" %>
<%@ Register Src="~/FrontEnd/UserControl/News/ucNews.ascx" TagPrefix="uc1" TagName="ucNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucListProduct runat="server" ID="ucListProduct" />
<div class="combo-option">
    <div class="product-title" style="float: left">
         <asp:Image ID="Image4" runat="server" ImageUrl="~/FrontEnd/image/properti.png" />
    </div>
    <div class="product-news" style="margin-right: 228px; float: right;">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/FrontEnd/image/news.png" />
    </div>
    <uc1:ucProductProperties runat="server" ID="ucProductProperties" />
    <uc1:ucNews runat="server" ID="ucNews" />
</div>
</asp:Content>
