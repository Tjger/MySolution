﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCapCha.ascx.vb" Inherits="HoaQuaVn.ucCapCha" %>

<table >
    <tr>
        <td colspan="2" style="text-align: center" >
            <asp:Image ID="ImgCaptcha" runat="server" />
        </td>
    </tr>
    <tr>
        <td valign="middle">
            <asp:Label ID="LblMsg" runat="server" Text="Enter the above code here:"></asp:Label>
            
          
        </td>
        <td>
            <asp:TextBox ID="TxtCpatcha" runat="server" Text=""></asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="middle">
            <asp:LinkButton ID="btnTryNewWords" runat="server" Font-Names="Tahoma" 
                Font-Size="Smaller" onclick="btnTryNewWords_Click">Can&#39;t read? Try different 
            words.</asp:LinkButton>
        </td>
    </tr>
</table>