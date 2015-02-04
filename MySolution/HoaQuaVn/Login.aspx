<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="HoaQuaVn.Login1" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hoa Qua Viet Nam - Admin</title>
    <meta name="description" content="Custom Login Form Styling with CSS3" />
    <meta name="keywords" content="css3, login, form, custom, input, submit, button, html5, placeholder" />
    <meta name="author" content="Codrops" />
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="~/BackEnd/css/style.css" />
    <script src="~/BackEnd/js/modernizr.custom.63321.js"></script>
    <!--[if lte IE 7]><style>.main{display:none;} .support-note .note-ie{display:block;}</style><![endif]-->
    <style>
        body {
            background: none repeat scroll 0 0 #428bca;
        }
    </style>
</head>
<body>
    <div class="container">
        <header>
            <h1><strong>Hệ Thống Quản Lý</strong> </h1>
            <h2>Hoa Quả Việt Nam</h2>        
        </header>

        <section class="main">
            <form class="form-2" runat="server">
                <h1><span class="log-in">Đăng nhập hệ thống</span> </h1>
                <p class="float">
                    <label for="login"><%--<i class="icon-user"></i>--%>Tên đăng nhập</label>
                    <asp:TextBox ID="txtUserName" runat="server"  placeholder="Tên tài khoản hoặc email"></asp:TextBox>
                    <%--<input type="text" name="login" placeholder="Tên tài khoản hoặc email">--%>
                </p>
                <p class="float">
                    <label for="password"><%--<i class="icon-lock"></i>--%>Mật khẩu</label>
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" placeholder="Mật khẩu" class="showpassword"></asp:TextBox>
                   <%-- <input type="password" name="password" placeholder="Mật khẩu" class="showpassword">--%>
                </p>
                <p class="clearfix">
                    <asp:Button ID="btnLogin" Width="305px" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
                    <%--<input type="submit" name="submit" value="Đăng nhập">--%>
                </p>
            </form>
            ​​
		
        </section>

    </div>
    <!-- jQuery if needed -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".showpassword").each(function (index, input) {
                var $input = $(input);
                $("<p class='opt'/>").append(
                    $("<input type='checkbox' class='showpasswordcheckbox' id='showPassword' />").click(function () {
                        var change = $(this).is(":checked") ? "text" : "password";
                        var rep = $("<input placeholder='Password' type='" + change + "' />")
                            .attr("id", $input.attr("id"))
                            .attr("name", $input.attr("name"))
                            .attr('class', $input.attr('class'))
                            .val($input.val())
                            .insertBefore($input);
                        $input.remove();
                        $input = rep;
                    })
                ).append($("<label for='showPassword'/>").text("Hiển thị mật khẩu")).insertAfter($input.parent());
            });

            $('#showPassword').click(function () {
                if ($("#showPassword").is(":checked")) {
                    $('.icon-lock').addClass('icon-unlock');
                    $('.icon-unlock').removeClass('icon-lock');
                } else {
                    $('.icon-unlock').addClass('icon-lock');
                    $('.icon-lock').removeClass('icon-unlock');
                }
            });
        });
		</script>
</body>
</html>
