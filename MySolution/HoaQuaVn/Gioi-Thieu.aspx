<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Gioi-Thieu.aspx.vb" Inherits="HoaQuaVn.Introduce" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="news-title">Giới Thiệu</div>
    <div id="powered"></div>
    <div>
        <div class="news-image" style="height: 141px;">
            <img src="FrontEnd/image/logo.png"/>
        </div>
        <div class="news-body">
             <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label>
           
        </div>
        <div class="subtitle">
        </div>

        <div class="fullwidth">
            <div class="fancy-header">

                <h2 class="highlight">Hoa Quả Việt Nam Cam Kết</h2>
            </div>

            <div class="service-row">
                <div class="service-features">
                    <div class="img-container">
                        <img src="FrontEnd/image/lab.png" alt="Service Features">
                    </div>
                    <h3>Chỉ bán hoa quả sạch</h3>

                </div>
                <!-- END ONE THIRD COLUMN -->

                <div class="service-features">
                    <div class="img-container">
                        <img src="FrontEnd/image/paperplane.png" alt="Service Features">
                    </div>

                    <h3>Chỉ bán sản phẩm có nguồn gốc rõ ràng</h3>

                </div>
                <!-- END ONE THIRD COLUMNS -->

                <div class="service-features">
                    <div class="img-container">
                        <img src="FrontEnd/image/like.png" alt="Service Features">
                    </div>
                    <h3>Miễn phí đổi trả hàng dập nát</h3>

                </div>
                <!-- END ONE THIRD COLUMNS -->




            </div>
            <!-- END ROW -->
        </div>
    </div>
</asp:Content>
