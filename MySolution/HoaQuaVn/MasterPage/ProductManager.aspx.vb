Imports Common
Public Class ProductManager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sSql As String = "SELECT * FROM Employee"
        Dim ds As New DataSet
        Core.InitAppSettingForDBA()
        Var.DBAMain = New Common.DBA(False)
        Var.DBAMain.FillDataset(sSql, ds, "test")
        If ds.Tables("test").Rows.Count > 0 Then

        End If


    End Sub


End Class