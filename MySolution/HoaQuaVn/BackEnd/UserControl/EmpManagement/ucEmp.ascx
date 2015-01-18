<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucEmp.ascx.vb" Inherits="HoaQuaVn.ucEmp" %>

<div style="line-height: 30px; margin-top: 36px;" class="item-info">

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
                <asp:TextBox ID="txtOldPas" runat="server"></asp:TextBox>
            </td>
             <td>

                <asp:TextBox ID="txtNewPas" runat="server"></asp:TextBox>
            </td>
            <td>

                <asp:TextBox ID="txtRenewPas" runat="server"></asp:TextBox>
            </td>
        </tr>
       
         <tr>
            <td>
                <asp:Label ID="lblErrMes" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
          
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
