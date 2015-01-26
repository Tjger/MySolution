Imports Common
Public Class Quy_Dinh_Chung
    Inherits System.Web.UI.Page
    Private ClsName = "Quy_Dinh_Chung"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA()
                LoadItemInfo()

            End If


        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Private Sub LoadItemInfo()
        Try
            Dim sSql As String = ""
            Dim ds As New DataSet
            sSql = "SELECT * FROM SysPara WHERE ComboID='Role' "
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            If Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo")) = False Then
                For Each row As DataRow In ds.Tables("LoadItemInfo").Rows
                    If Not Core.IsDBNullOrStringEmpty(row("ComboID")) Then
                        lblContents.Text = row("ItemID")

                    End If


                Next

            End If



        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

End Class