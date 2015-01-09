<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucReceiptDetail.ascx.vb" Inherits="HoaQuaVn.ucReceiptDetail" %>

<div style="line-height: 30px; margin-top: 36px;" class="item-info">

    <table>
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
         
            <td>
                <asp:Label ID="Label6" runat="server" Text="Mobile"></asp:Label>
            </td>
           
           
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
            </td>
           
            <td>

                <asp:TextBox ID="txtMobile" runat="server" Enabled="False"></asp:TextBox>
            </td>
            
            
        </tr>
        <tr>
             <td>
                <asp:Label ID="Label13" runat="server" Text="Email"></asp:Label>
            </td>
            
            <td>
                <asp:Label ID="Label14" runat="server" Text="Address"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>

                <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
            </td>
          
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Message"></asp:Label></td>
            
        </tr>
        <tr>
            <td colspan="2">
               <textarea id="txtSubcontent" runat="server" style="width: 709px; height: 103px;"></textarea>
                  
            </td>
           
        </tr>
                <tr>
            <td colspan="2">

                <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DropDownList ID="cboStatus" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        

        
    </table>
</div>
<br />

<div style="margin-top: 18px; margin-left: 276px;">
    <div style=" float: left; ">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>