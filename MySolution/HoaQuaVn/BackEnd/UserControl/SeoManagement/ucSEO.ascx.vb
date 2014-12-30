Imports Common
Public Class ucSEO
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucSEO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
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
            Dim sSql As String = "SELECT * FROM SEO"
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "SEO")
            If ds.Tables("SEO").Rows.Count > 0 Then
                GridView1.DataSource = ds.Tables("SEO")
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "BindData", ex.Message)
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
        Try
            Dim sSEOID As String = GridView1.Rows(e.RowIndex).Cells(0).Text
            Dim sSEO As String = DirectCast(GridView1.Rows(e.RowIndex).FindControl("txtSEO"), TextBox).Text
            Dim iResult As Integer = 0
            Dim sSQL As String = "Update SEO SET SEO= " & Core.SQLStr(sSEO) & " WHERE SeoID = " & Core.SQLStr(sSEOID)
            Var.DBAMain.Execute(sSQL, iResult)
            If iResult > 0 Then
                GridView1.EditIndex = -1
                BindData()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "GridView1_RowUpdating", ex.Message)
        End Try
        'viet sql update
        

    End Sub

    Protected Sub gvPerson_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            GridView1.PageIndex = e.NewPageIndex
            BindData()
        Catch ex As Exception
            Log.LogError(ClsName, "gvPerson_PageIndexChanging", ex.Message)
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
            Log.LogError(ClsName, "GridView1_RowDataBound", ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim sSeoID As String = GridView1.Rows(e.RowIndex).Cells(0).Text
            Dim iResult As Integer = 0
            Dim sSQL As String = "DELETE FROM SEO WHERE SeoID = " & Core.SQLStr(sSeoID)
            Var.DBAMain.Execute(sSQL, iResult)
            If iResult > 0 Then
                BindData()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "GridView1_RowDeleting", ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtSEONew.Text <> "" Then
                Dim iResult As Integer = 0
                Dim sSQL As String = String.Format("INSERT INTO SEO (SEO) VALUES ({0})", Core.SQLStr(txtSEONew.Text))
                Var.DBAMain.Execute(sSQL, iResult)
                If iResult > 0 Then
                    txtSEONew.Text = ""
                    BindData()
                End If
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try
    End Sub
End Class