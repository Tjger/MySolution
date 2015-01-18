Imports Common
Public Class Home
    Inherits System.Web.UI.MasterPage
    Private ClsName = "ucConfig"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
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
            sSql = "SELECT * FROM ComboItem "
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            For Each row As DataRow In ds.Tables("LoadItemInfo").Rows
                If Not Core.IsDBNullOrStringEmpty(row("ItemID")) Then
                    Select Case row("ComboID")
                        Case "ImageURL1"
                            Image1.ImageUrl = row("ItemID")
                        Case "ImageURL2"
                            Image2.ImageUrl = row("ItemID")
                        Case "ImageURL3"
                            Image3.ImageUrl = row("ItemID")
                        Case "TextInRed1"
                            txtInRed1.Text = row("ItemID")
                        Case "TextInRed2"
                            txtInRed2.Text = row("ItemID")
                        Case "TextInRed3"
                            txtInRed3.Text = row("ItemID")
                        Case "TextInWhite1"
                            txtInWhite1.Text = row("ItemID")
                        Case "TextInWhite2"
                            txtInWhite2.Text = row("ItemID")
                        Case "TextInWhite3"
                            txtInWhite3.Text = row("ItemID")

                    End Select

                End If


            Next

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

End Class