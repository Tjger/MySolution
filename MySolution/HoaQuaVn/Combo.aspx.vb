Imports Common
Public Class Combo
    Inherits System.Web.UI.Page
    Private ClsName = "Combo"
    Public sID As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            If Request.QueryString.Count > 0 Then
                sID = Request.QueryString("id")
                LoadComboDetail()
            End If

        End If
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

    Sub LoadComboDetail()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
            If sID <> "" Then
                sSQL = "SELECT * FROM Combo WHERE ComboID=" & Core.SQLStr(sID) & " AND Active='1'"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboDetail")
                If ds.Tables("LoadComboDetail").Rows.Count > 0 Then
                    lblComboName.Text = ds.Tables("LoadComboDetail").Rows(0)("ComboName")
                    lblDescription.Text = ds.Tables("LoadComboDetail").Rows(0)("Description")
                    lblItemList.Text = ds.Tables("LoadComboDetail").Rows(0)("ItemList")
                    lblPrice.Text = ds.Tables("LoadComboDetail").Rows(0)("ComboPrice")
                End If
            End If



        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub
End Class