Imports Common
Public Class ucCombo
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucCombo"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim sSql As String = "SELECT *  FROM Combo "
                Dim ds As New DataSet
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                Var.DBAMain.FillDataset(sSql, ds, "Combo")
                If ds.Tables("Combo").Rows.Count > 0 Then
                    GridView1.DataSource = ds.Tables("Combo")
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
       
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Response.Redirect("Admin.aspx?module=7&m=0")  'DataNavigateUrlFormatString="~/Admin.aspx?module=7&m=0"
    End Sub
End Class