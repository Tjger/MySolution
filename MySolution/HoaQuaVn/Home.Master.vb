Imports Common
Public Class Home
    Inherits System.Web.UI.MasterPage
    Private ClsName = "ucConfig"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Header.DataBind()
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA()
            LoadItemInfo()
            GetMenu()
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
            If Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo")) = False Then
                For Each row As DataRow In ds.Tables("LoadItemInfo").Rows
                    If Not Core.IsDBNullOrStringEmpty(row("ComboID")) Then
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
                            Case "ShowRegisterLogo"
                                lblShowRegisterLogo.Value = row("ItemID")

                            Case "RegisterLogoURL"
                                lblRegisterUrl.Value = row("ItemID")
                        End Select

                    End If


                Next

            End If

            

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub


    Sub GetMenu()
        Try
            Dim sSQL As String = String.Empty
            Dim ds As New DataSet
            Dim dtGroup As New DataTable
            Dim dtItem As New DataTable
            sSQL = "SELECT * FROM ItemGroup"
            Var.DBAMain.FillDataset(sSQL, ds, "Group")
            dtGroup = ds.Tables("Group")

            sSQL = "SELECT Item.*, ItemGroup.GroupName FROM Item INNER JOIN ItemGroup ON Item.GroupID = ItemGroup.GroupID Where Active = '1'"


            Var.DBAMain.FillDataset(sSQL, ds, "Item")
            dtItem = ds.Tables("Item")
            For i As Integer = 0 To dtGroup.Rows.Count - 1
                Dim mn As New MenuItem(dtGroup.Rows(i)("GroupName"), dtGroup.Rows(i)("GroupID"), "", "")
                Menu1.FindItem("Sản Phẩm").ChildItems.Add(mn)
                Dim dr() As DataRow = dtItem.Select("GroupName=" & Core.SQLStr(dtGroup.Rows(i)("GroupName")))
                For Each r As DataRow In dr
                    Dim mnu As New MenuItem(r("ItemName"), r("ItemID"), "", "Item.aspx?action=view&id=" & r("ItemID"))
                    Menu1.FindItem("Sản Phẩm").ChildItems.Item(i).ChildItems.Add(mnu)
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub
End Class