Imports Common
Public Class ucGroup
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sSql As String = "SELECT GroupName FROM ItemGroup"
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

End Class