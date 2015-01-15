Imports Common
Public Class ucListProduct
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucListProduct"

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
        Dim sDecription As String = ""
        Dim sItemList As String = ""
        Try
            sSQL = "SELECT * FROM Combo WHERE Active='1' ORDER BY AutoID DESC"
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("LoadCombo").Rows
                    If Core.IsDBNullOrStringEmpty(row("Description")) = False Then
                        If row("Description").ToString.Length > 80 Then
                            sDecription = row("Description").ToString.Substring(0, 80) & " ..."
                            row("Description") = sDecription
                        End If
                    End If
                    If Core.IsDBNullOrStringEmpty(row("ItemList")) = False Then
                        If row("ItemList").ToString.Length > 520 Then
                            If row("ItemList").ToString.Contains("<table>") = False Then
                                sItemList = row("ItemList").ToString.Substring(0, 520) & " ..."
                                row("ItemList") = sItemList
                            End If


                        End If
                    End If
                Next
                dtlComboList.DataSource = ds.Tables("LoadCombo")
                dtlComboList.DataBind()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub
End Class