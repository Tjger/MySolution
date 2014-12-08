Imports Common
Public Class GroupProductManager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sSql As String = "SELECT * FROM ItemGroup"
            Dim ds As New DataSet
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            Var.DBAMain.FillDataset(sSql, ds, "Group")
            If ds.Tables("Group").Rows.Count > 0 Then
                GridView1.DataSource = ds.Tables("Group")
                GridView1.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            Response.Redirect("AddNewGroup.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub
End Class