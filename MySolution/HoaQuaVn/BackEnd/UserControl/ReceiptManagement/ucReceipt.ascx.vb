Imports Common
Public Class ucReceipt
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucReceipt"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim sSql As String = "SELECT * FROM Receipt"
                Dim ds As New DataSet
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                Var.DBAMain.FillDataset(sSql, ds, "Receipt")
                If ds.Tables("Receipt").Rows.Count > 0 Then
                    GridView1.DataSource = ds.Tables("Receipt")
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
      
    End Sub

End Class