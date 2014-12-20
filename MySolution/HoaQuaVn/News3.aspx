<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/FrontEnd/Home.Master" CodeBehind="News3.aspx.vb" Inherits="HoaQuaVn.News3" %>
<%@ Register Src="~/FrontEnd/UserControl/News/ucNews.ascx" TagPrefix="uc1" TagName="ucNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="news-title">Các loại trái cây mát bổ tốt cho sức khỏe</div>
      <div id="powered"></div>
    <div class="news-image">
        <img src="FrontEnd/image/news/03.jpg"></div>
    <div class="news-body">
         Có nhiều cách giúp cơ thể bạn giải nhiệt trong ngày hè nhưng một trong những cách hiệu quả nhất là bổ sung những loại trái cây sau:
 
Mơ
 
Trong trái mơ có chứa nhiều kẽm, magie, khoáng chất điển hình như vitamin C, sắt, beta carotene đều có lợi cho sức khỏe, tăng cường sinh lực. Nước mơ ngâm cũng là loại nước trái cây giải nhiệt. Với trái mơ, bảo quản trong tủ lạnh giúp quả tươi lâu hơn.
 
Dâu tây
 
Dâu tây thuộc nhóm quả mọng và rất phổ biến trong những ngày nắng nóng. Dâu tây không chỉ hấp dẫn bởi màu sắc mà còn bởi, trong thành phần của nó, có nhiều vitamin C, kali, sắt, natri, ít calo. Vậy nên, không chỉ là loại trái cây mát, bổ dưỡng, người ăn kiêng, thực hiện chế độ giảm cân, cũng có thể dùng dâu tây. Để lựa chọn được trái dâu tây ngon, nên chọn quả căng mọng, tươi, không dập nát (dâu tây rất dễ dập nát), chín đều, không có chấm trắng hoặc chấm xanh bên ngoài.
 
 
Dưa hấu
 
Đây là quả thuộc loại trái mát đầu bảng trong ngày hè. Dưa hấu có chứa rất ít calo, nhưng nhiều vitamin C và hàm lượng cao chất pectin. Đặc biệt hàm lượng nước lớn trong dưa hấu (92% nước) sẽ giúp thỏa mãn cơn khát và loại trừ nguy cơ khử nước trong cơ thể - một hiện tượng rất thường gặp trong những ngày hè.
 
Cherry
 
Chứa hàm lượng lớn giá trị dinh dưỡng do có nhiều enzymes, vitamin và khoáng chất. Có thể ăn trực tiếp cherry hoặc thêm vào các món kem, chè và salat.
 
Dứa
 
Chứa nhiều khoáng chất, kali, photpho, magie, canxi, sắt, lượng lớn vitamin C, và một loại enzyme mang tên bromelain – chất kích thích tiêu hóa hiệu quả. Với dứa, nên lựa chọn quả có mắt lớn, mùi thơm, chín vàng đều, không dập nát.
 

Đào có thể dễ dàng bổ sung hàm lượng beta – caroten và kali trong cơ thể. Hàm lượng vitamin C dồi dào trong đào sẽ giúp cơ thể thanh nhiệt hiệu quả.
    </div>
         <div class="news-detail">Tin Liên Quan
               <div id="powered"></div>
          <uc1:ucNews runat="server" ID="ucNews" />   
     </div>
</asp:Content>
