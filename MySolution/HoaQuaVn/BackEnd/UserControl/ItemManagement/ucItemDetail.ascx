﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucItemDetail.ascx.vb" Inherits="HoaQuaVn.ucItemDetail" %>
<style>
    input[type="text"], input[type="submit"], select, textarea, Button {
        border: 3px solid #ebe6e2;
        border-radius: 5px;
        display: block;
        font-family: "Lato",Calibri,Arial,sans-serif;
        font-size: 13px;
        font-weight: 400;
        font-weight: 400;
        margin-bottom: 5px;
        padding: 5px;
        transition: all 0.3s ease-out 0s;
        width: 100%;
    }
</style>

<asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
<asp:TextBox ID="txtItemName" runat="server" Width="184px"></asp:TextBox>
<asp:CheckBox ID="chkActive" Text="Active" runat="server" />
<asp:CheckBox ID="chkHot" Text="Hot" runat="server" />
<br />

<asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
<asp:DropDownList ID="cboGroup" runat="server" Width="300px">
</asp:DropDownList>
<br />

<asp:Label ID="Label3" runat="server" Text="Image"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label ID="Label7" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng người lớn/100gr/ngày"></asp:Label>
<br />
<asp:Label ID="Label8" runat="server" Text="Vitamin"></asp:Label>
<br />
<asp:TextBox ID="txtAdultVitamin" runat="server" Width="184px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label9" runat="server" Text="Năng Lượng"></asp:Label>
<br />
<asp:TextBox ID="txtAdultEnergy" runat="server" Width="184px"></asp:TextBox>
<br />
<br />
<br />
<asp:Label ID="Label10" runat="server" Text="Tỷ lệ đáp ứng nhu cầu dinh dưỡng trẻ em/100gr/ngày"></asp:Label>
<br />
<asp:Label ID="Label11" runat="server" Text="Vitamin"></asp:Label>
<br />
<asp:TextBox ID="txtChildVitamin" runat="server" Width="184px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label12" runat="server" Text="Năng Lượng"></asp:Label>
<br />
<asp:TextBox ID="txtChildEnergy" runat="server" Width="184px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
<br />
<textarea id="txtDescription" runat="server" width="400px"></textarea>
<br />
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Hàm Lượng Vitamin"></asp:Label>
<br />
<textarea id="txtVitaminElement" runat="server" width="400px">
    <ul>
<li>Vitamin A - 76 IU</li>
<li>Vitamin B1 (thiamine) - 0.037mg</li>
</ul>
    
    
    Vitamin B2 (riboflavin) - 0.086mg
    Niacin - 0.785 mg
    Axit Folic - 24 mcg
    Axit Pantothenic - 0.394 mg
    Vitamin B6 - 0.433 mg
    Vitamin C - 10.3 mg
    Vitamin E - 0.12 mg
    Vitamin K - 0.6 mcg
</textarea>
<br />
<br />
<br />
<asp:Label ID="Label6" runat="server" Text="Hàm Lượng Chất Khoáng"></asp:Label>
<br />
<textarea id="txtMineralsElement" runat="server" width="400px"></textarea>
<br />
<br />
<div style="width: 100px; float: left;">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
</div>
<div style="width: 100px;">
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
</div>
