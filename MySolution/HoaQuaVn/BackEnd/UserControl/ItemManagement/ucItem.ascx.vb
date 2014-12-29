Imports Common
Public Class ucItem
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCboGroup()
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
        End If
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
        Dim sHot As String = String.Empty
        If chkHot.Checked Then
            sHot = "1"
        Else
            sHot = "0"
        End If

       

        Dim sSql As String = String.Format("INSERT INTO Item (ItemID, ItemName, Description,GroupID,Hot) VALUES ({0},{1},{2},{3})", Core.SQLStr(sItemID), Core.SQLStr(txtItemName.Text), Core.SQLStr(txtDescription.Value), Core.SQLStr(cboGroup.SelectedValue))
        If Var.DBAMain.Execute(sSql) Then
            Response.Redirect("Admin.aspx?module=2")
        End If
    End Sub

End Class