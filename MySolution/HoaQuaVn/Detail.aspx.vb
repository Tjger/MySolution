Imports Common
Public Class Detail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    '    Response.Redirect("Index.aspx")
    'End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Dim sSubject As String = "Đơn Hàng - Combo1 - " & Date.Today.ToString("dd/MM/yyyy")
            Dim sBody As String = "Tên: " & txtGuestName.Text & vbCrLf
            sBody &= "Điện Thoại: " & txtGuestMobile.Text & vbCrLf
            sBody &= "Email: " & txtGuestMail.Text & vbCrLf
            sBody &= "Message: " & txtMessage.Value & vbCrLf
            If clsEmail.SendEmail(sSubject, "hoaquavietnam168@gmail.com", sBody) Then
                Dim myStringVariable As String = String.Empty
                myStringVariable = "Cảm Ơn Quý Khách, Chúng Tôi Sẽ Nhanh Chóng Liên Hệ Để Xác Nhận Đơn Hàng"
                ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + myStringVariable + "');", True)

            End If
            txtGuestName.Text = ""
            txtGuestMobile.Text = ""
            txtGuestMail.Text = ""
            txtMessage.Value = ""
        Catch ex As Exception

        End Try
    End Sub
End Class