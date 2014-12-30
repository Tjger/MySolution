Imports Common
Public Class ucItem
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucItem"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim sSql As String = "SELECT Item.*, ItemGroup.GroupName  FROM Item "
                sSql &= " LEFT OUTER JOIN ItemGroup ON Item.GroupID = ItemGroup.GroupID "
                Dim ds As New DataSet
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                Var.DBAMain.FillDataset(sSql, ds, "Item")
                If ds.Tables("Item").Rows.Count > 0 Then
                    GridView1.DataSource = ds.Tables("Item")
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
       
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Response.Redirect("Admin.aspx?module=6&m=0")
    End Sub
End Class