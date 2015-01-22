<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="News.aspx.vb" Inherits="HoaQuaVn.News" %>

<%@ Register Src="~/FrontEnd/UserControl/News/ucNews.ascx" TagPrefix="uc1" TagName="ucNews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news-title"><asp:Label ID="lblNewTitle" runat="server"></asp:Label></div>
      <div id="powered"></div>
    <div class="news-image">
        <asp:Image ID="NewImage" runat="server" Width="420px" Height="310px"/></div>
    <div class="news-body">
        <asp:Label ID="lblNewDes" runat="server"></asp:Label>
    </div>

     <div class="news-detail">Tin Liên Quan
               <div id="powered"></div>
          <uc1:ucNews runat="server" ID="ucNews" />   
     </div>

</asp:Content>
