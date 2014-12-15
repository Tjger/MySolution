<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/FrontEnd/Home.Master" CodeBehind="Index.aspx.vb" Inherits="HoaQuaVn.Index1" %>
<%@ Register src="../../UserControl/Properties/ucProperties.ascx" tagname="ucProperties" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    </p>
    <uc1:ucProperties ID="ucProperties1" runat="server" />
</asp:Content>
