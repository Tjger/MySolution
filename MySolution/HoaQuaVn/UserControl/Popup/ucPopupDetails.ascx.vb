Imports Common

Public Class ucPopupDetails
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Core.InitAppSettingForDBA()
        Var.DBAMain = New Common.DBA(False)
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    End Sub
End Class