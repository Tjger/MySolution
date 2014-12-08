Imports Common
Public Class AddNewItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Core.InitAppSettingForDBA()
        Var.DBAMain = New Common.DBA(False)
        LoadCboGroup()
    End Sub

    Private Sub LoadCboGroup()
        Try
            Dim sSql As String = "SELECT * FROM ItemGroup"
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadCboGroup")
            cboGroup.DataSource = ds.Tables("LoadCboGroup")

            cboGroup.DataTextField = "GroupName"
            cboGroup.DataValueField = "GroupID"
            cboGroup.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sItemID As Integer = Core.GetID("ItemID", "Item")
        Dim sSql As String = String.Format("INSERT INTO Item (ItemID, ItemName, Description,GroupID) VALUES ({0},{1})", Core.SQLStr(sItemID), Core.SQLStr(txtItemName.Text), Core.SQLStr(txtDescription.Value), Core.SQLStr(cboGroup.SelectedValue))
        If Var.DBAMain.Execute(sSql) Then
            Response.Redirect("GroupProductManager.aspx")
        End If
    End Sub
End Class