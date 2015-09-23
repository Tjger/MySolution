Imports Common
Public Class ucReceipt
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucReceipt"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                ReceiptCalendar.SelectedDate = DateTime.Now
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                BindData()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try

    End Sub

    Private Sub BindData()
        Try
            Dim sSql As String = String.Format("SELECT *,'' AS StatusView FROM Receipt WHERE DATEDIFF(DAY,CONVERT(VARCHAR(10),CreatedDate,110),{0}) = 0 AND Status <> {1} ORDER BY Status ", Core.SQLStr(Core.SQLDate(ReceiptCalendar.SelectedDate)), Core.SQLStr(Var.FruiltReceiptStatus.Spam))
            Dim ds As New DataSet

            Var.DBAMain.FillDataset(sSql, ds, "Receipt")
            If ds.Tables("Receipt").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("Receipt").Rows
                    Select Case row("Status")
                        Case Var.FruiltReceiptStatus.News
                            row("StatusView") = "News"
                        Case Var.FruiltReceiptStatus.Spam
                            row("StatusView") = "Spam"
                        Case Var.FruiltReceiptStatus.Close
                            row("StatusView") = "Close"
                    End Select

                Next
                GridView1.DataSource = ds.Tables("Receipt")
                GridView1.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ReceiptCalendar_SelectionChanged(sender As Object, e As EventArgs) Handles ReceiptCalendar.SelectionChanged
        BindData()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim sReceiptNo As String = GridView1.Rows(e.RowIndex).Cells(0).Text
            Dim iResult As Integer = 0
            Dim sSQL As String = "DELETE FROM Receipt WHERE ReceiptNo = " & Core.SQLStr(sReceiptNo)
            Var.DBAMain.Execute(sSQL, iResult)
            If iResult > 0 Then
                BindData()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "GridView1_RowDeleting", ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate Then
                    DirectCast(e.Row.Cells(8).Controls(0), LinkButton).Attributes("OnClick") = "return confirm('Do you want to delete?')"
                    Dim x As Integer = 1
                End If

            End If

        Catch ex As Exception
            Log.LogError(ClsName, "GridView1_RowDataBound", ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            GridView1.PageIndex = e.NewPageIndex
            BindData()
        Catch ex As Exception

        End Try
    End Sub
End Class