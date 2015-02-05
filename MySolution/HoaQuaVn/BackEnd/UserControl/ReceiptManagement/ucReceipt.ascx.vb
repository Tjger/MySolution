﻿Imports Common
Public Class ucReceipt
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucReceipt"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                ReceiptCalendar.SelectedDate = DateTime.Now
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                LoadReceipt()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
      
    End Sub

    Private Sub LoadReceipt()
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
        LoadReceipt()
    End Sub
End Class