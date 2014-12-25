Imports Common
Public Class ucGroup
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
        End If
    End Sub

    Private Sub BindData()
        Try
            Dim sSql As String = "SELECT * FROM ItemGroup"
            Dim ds As New DataSet
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
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
    Sub AddNewGroup()

    End Sub
    Sub DeleteGroup()

    End Sub
    'Protected Sub EditGroup(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
    '    GridView1.EditIndex=
    'End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        BindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        'viet sql update
        Dim sGroupID As String =  DirectCast(GridView1.FooterRow.FindControl("txtGroupID"),TextBox).Text
        Dim sGroupName As String = DirectCast(GridView1.FooterRow.FindControl("txtGroupName"),TextBox).Text

        Dim sSQL As String = "Update ItemGroup SET GroupName= " & sGroupName
    End Sub
End Class