Imports Common
Public Class Item
    Inherits System.Web.UI.Page
    Private ClsName = "Combo"
    Public sID As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            If Request.QueryString.Count > 0 Then
                sID = Request.QueryString("MyTitleId")
                LoadComboDetail()
            End If

        End If
    End Sub

    Sub LoadComboDetail()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Dim sGroupID As String = ""
        Try
            If sID <> "" Then
                sSQL = "SELECT * FROM Item WHERE ItemID=" & Core.SQLStr(sID) & " AND Active='1'"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboDetail")
                If ds.Tables("LoadComboDetail").Rows.Count > 0 Then
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("ItemImageURL")) Then
                        ItemImage.ImageUrl = ds.Tables("LoadComboDetail").Rows(0)("ItemImageURL")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("ItemName")) Then
                        lblName.Text = ds.Tables("LoadComboDetail").Rows(0)("ItemName")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("Description")) Then
                        lblDescription.Text = ds.Tables("LoadComboDetail").Rows(0)("Description")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("ElementInfo")) Then
                        lblItemList.Text = ds.Tables("LoadComboDetail").Rows(0)("ElementInfo")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("ItemPrice")) Then
                        lblItemPrice.Text = ds.Tables("LoadComboDetail").Rows(0)("ItemPrice")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("GroupID")) Then
                        sGroupID = ds.Tables("LoadComboDetail").Rows(0)("GroupID")
                    End If

                End If
                If sGroupID <> "" Then
                    sSQL = "SELECT * FROM Item WHERE ItemID<>" & Core.SQLStr(sID) & " AND Active='1' AND GroupID=" & Core.SQLStr(sGroupID)
                    Var.DBAMain.FillDataset(sSQL, ds, "LoadItemRelativeDetail")
                    If ds.Tables("LoadItemRelativeDetail").Rows.Count > 0 Then
                        dtlItemRelativeLists.DataSource = ds.Tables("LoadItemRelativeDetail")
                        dtlItemRelativeLists.DataBind()
                    End If
                End If


            End If



        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If txtGuestName.Text = "" Or txtGuestMobile.Text = "" Then
                lblErrMes.Text = "Vui Lòng Điền Đầy Đủ Thông Tin Cần Thiết"
                Exit Sub
            End If
            If ucCapCha.IsValid = False Then
                lblErrMes.Text = "Vui Lòng Điền Đúng Mã Bảo Vệ"
                Exit Sub
            End If

            If SaveReceipt() Then
                Response.Redirect("Index.aspx?action=1")
                'Dim myStringVariable As String = String.Empty
                'myStringVariable = "Cảm Ơn Quý Khách, Chúng Tôi Sẽ Nhanh Chóng Liên Hệ Để Xác Nhận Đơn Hàng"
                'ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + myStringVariable + "');", True)
            End If

            'Dim sSubject As String = "Đơn Hàng - Combo1 - " & Date.Today.ToString("dd/MM/yyyy")
            'Dim sBody As String = "Tên: " & txtGuestName.Text & vbCrLf
            'sBody &= "Điện Thoại: " & txtGuestMobile.Text & vbCrLf
            'sBody &= "Email: " & txtGuestMail.Text & vbCrLf
            'sBody &= "Message: " & txtMessage.Value & vbCrLf
            'If clsEmail.SendEmail(sSubject, "hoaquavietnam168@gmail.com", sBody) Then
            '    Dim myStringVariable As String = String.Empty
            '    myStringVariable = "Cảm Ơn Quý Khách, Chúng Tôi Sẽ Nhanh Chóng Liên Hệ Để Xác Nhận Đơn Hàng"
            '    ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + myStringVariable + "');", True)

            'End If
            'txtGuestName.Text = ""
            'txtGuestMobile.Text = ""
            'txtGuestMail.Text = ""
            'txtGuestAddress.Text = ""
            'txtMessage.Value = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Function SaveReceipt() As Boolean
        Dim bFlag As Boolean = False
        Try
            Dim sSubject As String = "Đơn Hàng - " & lblName.Text & " - " & Date.Today.ToString("dd/MM/yyyy")
            Dim sSql As String = String.Format("INSERT INTO Receipt (GuestName, GuestMobile, GuestEmail, GuestAddress,Status, CreatedDate, Message) VALUES(N{0}, N{1},N{2}, N{3},N{4}, N{5},N{6})", Core.SQLStr(txtGuestName.Text), Core.SQLStr(txtGuestMobile.Text), Core.SQLStr(txtGuestMail.Text), Core.SQLStr(txtGuestAddress.Text), Core.SQLStr(1), Core.SQLStr(Core.SQLDate(DateTime.Now)), Core.SQLStr(sSubject & " - " & txtMessage.Value))
            bFlag = Var.DBAMain.Execute(sSql)
        Catch ex As Exception

        End Try
        Return bFlag
    End Function

   

End Class