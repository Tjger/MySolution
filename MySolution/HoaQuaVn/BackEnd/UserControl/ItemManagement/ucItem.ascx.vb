Imports Common
Public Class ucItem
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

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



End Class