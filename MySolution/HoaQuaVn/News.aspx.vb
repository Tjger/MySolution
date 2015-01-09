Imports Common
Public Class News
    Inherits System.Web.UI.Page
    Private ClsName = "News"
    Public sID As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            If Request.QueryString.Count > 0 Then
                sID = Request.QueryString("id")
            End If
            LoadComboDetail()
        End If
    End Sub

    Sub LoadComboDetail()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
            If sID <> "" Then
                sSQL = "SELECT * FROM News WHERE AutoID=" & Core.SQLStr(sID) & " AND Active='1'"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboDetail")
                If ds.Tables("LoadComboDetail").Rows.Count > 0 Then
                    lblNewTitle.Text = ds.Tables("LoadComboDetail").Rows(0)("Title")
                    NewImage.ImageUrl = ds.Tables("LoadComboDetail").Rows(0)("Image")
                    lblNewDes.Text = ds.Tables("LoadComboDetail").Rows(0)("MainContent")

                End If
            Else
                sSQL = "SELECT TOP 1 * FROM NEWS WHERE Active='1' ORDER BY DateInput DESC"
                Var.DBAMain.FillDataset(sSQL, ds, "LoadComboDetail")
                If ds.Tables("LoadComboDetail").Rows.Count > 0 Then
                    lblNewTitle.Text = ds.Tables("LoadComboDetail").Rows(0)("Title")
                    NewImage.ImageUrl = ds.Tables("LoadComboDetail").Rows(0)("Image")
                    lblNewDes.Text = ds.Tables("LoadComboDetail").Rows(0)("MainContent")

                End If
            End If



        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub
End Class