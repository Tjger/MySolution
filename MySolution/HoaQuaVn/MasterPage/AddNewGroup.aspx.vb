Imports Common
Public Class AddNewGroup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Core.InitAppSettingForDBA()
        Var.DBAMain = New Common.DBA(False)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sGroupID As Integer = Core.GetID("GroupID", "ItemGroup")
        Dim sSql As String = String.Format("INSERT INTO ItemGroup (GroupID, GroupName) VALUES ({0},{1})", Core.SQLStr(sGroupID), Core.SQLStr(txtGroupName.Text))
        If Var.DBAMain.Execute(sSql) Then
            Response.Redirect("GroupProductManager.aspx")
        End If
    End Sub


End Class