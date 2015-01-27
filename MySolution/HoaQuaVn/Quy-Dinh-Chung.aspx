<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Quy-Dinh-Chung.aspx.vb" Inherits="HoaQuaVn.Quy_Dinh_Chung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="news-title"><asp:Label ID="lblNewTitle" runat="server"></asp:Label></div>
      <div id="powered"></div>
    <div class="news-body">
         <asp:Label ID="lblContents" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
