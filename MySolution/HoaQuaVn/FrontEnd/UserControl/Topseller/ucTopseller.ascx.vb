Imports Common
Public Class ucTopseller
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucTopseller"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            LoadCombo()
        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
            sSQL = "SELECT * FROM Item WHERE Active='1' AND Hot = '1' ORDER BY CreatedDate DESC "
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                dtlHotItemList.DataSource = ds.Tables("LoadCombo")
                dtlHotItemList.DataBind()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub
End Class