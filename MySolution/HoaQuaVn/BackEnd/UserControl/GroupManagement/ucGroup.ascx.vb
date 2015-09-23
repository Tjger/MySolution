Imports Common
Public Class ucGroup
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            BindData()
        End If
    End Sub

    Private Sub BindData()
        Try
            Dim sSql As String = "SELECT * FROM ItemGroup"
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "Group")
            If ds.Tables("Group").Rows.Count > 0 Then
                GridView1.DataSource = ds.Tables("Group")
                GridView1.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        BindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        'viet sql update
        Dim sGroupID As String = GridView1.Rows(e.RowIndex).Cells(0).Text
        Dim sGroupName As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("txtGroupName"), TextBox).Text
        Dim iResult As Integer = 0
        Dim sSQL As String = "Update ItemGroup SET GroupName=N" & Core.SQLStr(sGroupName) & " WHERE GroupID = " & Core.SQLStr(sGroupID)
        Var.DBAMain.Execute(sSQL, iResult)
        If iResult > 0 Then
            GridView1.EditIndex = -1
            BindData()
        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            GridView1.PageIndex = e.NewPageIndex
            BindData()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate Then
                    DirectCast(e.Row.Cells(3).Controls(0), LinkButton).Attributes("OnClick") = "return confirm('Do you want to delete?')"
                    Dim x As Integer = 1
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim sGroupID As String = GridView1.Rows(e.RowIndex).Cells(0).Text
            'Dim sGroupName As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("txtGroupName"), TextBox).Text
            Dim iResult As Integer = 0
            Dim sSQL As String = "DELETE FROM ItemGroup WHERE GroupID = " & Core.SQLStr(sGroupID)
            Var.DBAMain.Execute(sSQL, iResult)
            If iResult > 0 Then
                BindData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtGroupNameNew.Text <> "" Then
                Dim iResult As Integer = 0
                Dim sSQL As String = String.Format("INSERT INTO ItemGroup (GroupName) VALUES (N{0})", Core.SQLStr(txtGroupNameNew.Text))
                Var.DBAMain.Execute(sSQL, iResult)
                If iResult > 0 Then
                    txtGroupNameNew.Text = ""
                    BindData()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class