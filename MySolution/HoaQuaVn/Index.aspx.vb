Imports Common
Public Class Index1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sModule As String = String.Empty
            If Request.QueryString.Keys.Count > 0 Then
                sModule = Request.QueryString("action").ToString()
                Select Case Convert.ToInt32(sModule)
                    Case 1
                        Dim myStringVariable As String = String.Empty
                        myStringVariable = "Cảm Ơn Quý Khách, Chúng Tôi Sẽ Nhanh Chóng Liên Hệ Để Xác Nhận Đơn Hàng"
                        ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + myStringVariable + "');", True)
                End Select
         
            End If
        End If

    End Sub


End Class