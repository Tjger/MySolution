Imports Common
Public Class ucNews1
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucNews1"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim sSql As String = "SELECT *  FROM News "
                Dim ds As New DataSet
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                Var.DBAMain.FillDataset(sSql, ds, "News")
                If ds.Tables("News").Rows.Count > 0 Then
                    GridView1.DataSource = ds.Tables("News")
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try

    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Response.Redirect("Admin.aspx?module=8&m=0")
    End Sub

End Class