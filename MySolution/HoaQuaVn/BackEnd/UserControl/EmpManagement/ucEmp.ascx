<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucEmp.ascx.vb" Inherits="HoaQuaVn.ucEmp" %>

<div style="line-height: 30px;" class="item-info">
      <asp:Label ID="Label9" runat="server" Text="Change password"></asp:Label>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="New Password"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Retype New Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtOldPas" TextMode="Password" runat="server"></asp:TextBox>
            </td>
             <td>

                <asp:TextBox ID="txtNewPas"  TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>

                <asp:TextBox ID="txtRenewPas" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
       
         <tr>
            <td>
                &nbsp;</td>
          
        </tr>
    </table>
</div>

<div style="margin-top: 18px; margin-left: 276px; float: left;">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
        </div>
    </div>
    <div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
    </div>
</div>


<div style="line-height: 30px; margin-top: 90px;" class="item-info">
     <asp:Label ID="Label8" runat="server" Text="Create Emp"></asp:Label>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Emp Login Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Emp Login Password"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Super Admin Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEmpLoginName"  TextMode="Password" runat="server"></asp:TextBox>
            </td>
             <td>

                <asp:TextBox ID="txtEmpLoginpass" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>

                <asp:TextBox ID="txtSuperAdminPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        
    </table>
</div>

<div class="SaveCancel">
    <div style="float: left;">
        <div style="float: right; margin-right: 7px;">
            <asp:Button ID="btnCreatEmp" runat="server" Text="Save" Width="80px" />
        </div>
    </div>

</div>
<div style="width:100%; float: left;"> <asp:Label ID="lblErrMes" runat="server" Text="" ForeColor="Red"></asp:Label></div>