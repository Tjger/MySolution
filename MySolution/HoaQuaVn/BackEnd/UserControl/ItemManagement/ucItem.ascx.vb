Imports Common
Public Class ucItem
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucItem"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                BindData()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
       
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Response.Redirect("Admin.aspx?module=6&m=0")
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            GridView1.PageIndex = e.NewPageIndex
            BindData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindData()
        Try

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
        Catch ex As Exception
            Log.LogError(ClsName, "BindData", ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim sItemID As String = GridView1.Rows(e.RowIndex).Cells(0).Text
            Dim iResult As Integer = 0
            Dim sSQL As String = "DELETE FROM Item WHERE ItemID = " & Core.SQLStr(sItemID)
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
                    DirectCast(e.Row.Cells(9).Controls(0), LinkButton).Attributes("OnClick") = "return confirm('Do you want to delete?')"
                    Dim x As Integer = 1
                End If

            End If

        Catch ex As Exception
            Log.LogError(ClsName, "GridView1_RowDataBound", ex.Message)
        End Try
    End Sub

End Class