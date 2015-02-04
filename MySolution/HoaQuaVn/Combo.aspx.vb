Imports Common
Public Class Combo
    Inherits System.Web.UI.Page
    Private ClsName = "Combo"
    Private sID As String = String.Empty
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
            End If

            'Dim sSubject As String = "Đơn Hàng - " & lblComboName.Text & " - " & Date.Today.ToString("dd/MM/yyyy")
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
            Dim sSubject As String = "Đơn Hàng - " & lblComboName.Text & " - " & Date.Today.ToString("dd/MM/yyyy")
            Dim sSql As String = String.Format("INSERT INTO Receipt (GuestName, GuestMobile, GuestEmail, GuestAddress,Status, CreatedDate, Message) VALUES(N{0}, N{1},N{2}, N{3},N{4}, N{5},N{6})", Core.SQLStr(txtGuestName.Text), Core.SQLStr(txtGuestMobile.Text), Core.SQLStr(txtGuestMail.Text), Core.SQLStr(txtGuestAddress.Text), Core.SQLStr(1), Core.SQLStr(Core.SQLDate(DateTime.Now)), Core.SQLStr(sSubject & " - " & txtMessage.Value))
            bFlag = Var.DBAMain.Execute(sSql)
        Catch ex As Exception

        End Try
        Return bFlag
    End Function

    Sub LoadComboDetail()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Dim sDecription As String = ""
        Dim sItemList As String = ""
        Try
            If sID <> "" Then
                sSQL = "SELECT * FROM Combo WHERE ComboID=" & Core.SQLStr(sID) & " AND Active='1'"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboDetail")
                If ds.Tables("LoadComboDetail").Rows.Count > 0 Then
                    lblComboName.Text = ds.Tables("LoadComboDetail").Rows(0)("ComboName")
                    lblDescription.Text = ds.Tables("LoadComboDetail").Rows(0)("Description")
                    lblItemList.Text = ds.Tables("LoadComboDetail").Rows(0)("ItemList")
                    lblPrice.Text = ds.Tables("LoadComboDetail").Rows(0)("ComboPrice")
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadComboDetail").Rows(0)("ComboImageURL")) Then
                        ItemImage.ImageUrl = ds.Tables("LoadComboDetail").Rows(0)("ComboImageURL")
                    End If
                End If

                sSQL = "SELECT * FROM Combo WHERE ComboID <>" & Core.SQLStr(sID) & " AND Active='1'"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboRelateDetail")
                If ds.Tables("LoadComboRelateDetail").Rows.Count > 0 Then
                    For Each row As DataRow In ds.Tables("LoadComboRelateDetail").Rows
                        If Core.IsDBNullOrStringEmpty(row("Description")) = False Then
                            If row("Description").ToString.Length > 80 Then
                                sDecription = row("Description").ToString.Substring(0, 80) & " ..."
                                row("Description") = sDecription
                            End If
                        End If
                        If Core.IsDBNullOrStringEmpty(row("ItemList")) = False Then
                            If row("ItemList").ToString.Length > 520 Then
                                If row("ItemList").ToString.Contains("<table>") = False Then
                                    sItemList = row("ItemList").ToString.Substring(0, 520) & " ..."
                                    row("ItemList") = sItemList
                                End If


                            End If
                        End If
                    Next
                    dtlComboRelateList.DataSource = ds.Tables("LoadComboRelateDetail")
                    dtlComboRelateList.DataBind()
                End If
            End If



        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Public Shared Function GenerateURL(Title As Object) As String
        Dim strTitle As String = Title.ToString()


        strTitle = strTitle.Trim()


        strTitle = strTitle.Trim("-"c)

        strTitle = strTitle.ToLower()
        Dim chars As Char() = "$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray()
        strTitle = strTitle.Replace("c#", "C-Sharp")
        strTitle = strTitle.Replace("vb.net", "VB-Net")
        strTitle = strTitle.Replace("asp.net", "Asp-Net")


        strTitle = strTitle.Replace(".", "-")

        For i As Integer = 0 To chars.Length - 1
            Dim strChar As String = chars.GetValue(i).ToString()
            If strTitle.Contains(strChar) Then
                strTitle = strTitle.Replace(strChar, String.Empty)
            End If
        Next


        strTitle = strTitle.Replace(" ", "-")


        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("-----", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("--", "-")


        strTitle = strTitle.Trim()


        strTitle = strTitle.Trim("-"c)

        strTitle = (Convert.ToString("/Combo/") & strTitle) & ".aspx"

        Return strTitle
    End Function

End Class