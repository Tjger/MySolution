Imports Common
Public Class Home
    Inherits System.Web.UI.MasterPage
    Private ClsName = "ucConfig"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Page.Header.DataBind()
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA()
                LoadItemInfo()
                GetMenu()
            End If

            
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Private Sub LoadItemInfo()
        Try
            Dim sSql As String = ""
            Dim ds As New DataSet
            sSql = "SELECT * FROM SysPara "
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

                                If row("ItemID").ToString.Contains("http://") Then
                                    lblRegisterUrl.Value = row("ItemID")
                                Else
                                    lblRegisterUrl.Value = "http://" & row("ItemID").ToString.Trim
                                End If

                            Case "Email"
                                lblEmails.Value = "mailto:" & row("ItemID")
                            Case "Skype"
                                lblSkype.Value = "skype:" & row("ItemID") & "?chat"
                            Case "Yahoo"
                                lblYahoo.Value = "ymsgr:sendim?" & row("ItemID")
                            Case "Facebook"
                                lblFacebookUrl.Value = row("ItemID")
                            Case "GooglePlus"
                                lblGooglePlusUrl.Value = row("ItemID")
                            Case "LogoPic"
                                Image4.ImageUrl = row("ItemID")
                                Image5.ImageUrl = row("ItemID")
                            Case "PicOne"
                                Image6.ImageUrl = row("ItemID")
                            Case "RegisterLogo"
                                Image7.ImageUrl = row("ItemID")
                            Case "ContactsFooter"
                                lblContatcFooter.Text = row("ItemID")
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
                Menu2.FindItem("Đặc Tính Sản Phẩm").ChildItems.Add(mn)
                Dim dr() As DataRow = dtItem.Select("GroupName=" & Core.SQLStr(dtGroup.Rows(i)("GroupName")))
                For Each r As DataRow In dr
                    Dim mnu As New MenuItem(r("ItemName"), r("ItemID"), "", Core.GenerateURL(r("ItemName"), r("ItemID"), "/san-pham/"))
                    Menu2.FindItem("Đặc Tính Sản Phẩm").ChildItems.Item(i).ChildItems.Add(mnu)
                Next
            Next

            For ii As Integer = 1 To 6
                Dim sName As String = ""
                Select Case ii
                    Case 1
                        sName = "Chính Sách Đổi Trả Hàng"
                    Case 2
                        sName = "Hướng Dẫn Mua Hàng"
                    Case 3
                        sName = "Phương Thức Thanh Toán"
                    Case 4
                        sName = "Phương Thức Vận Chuyển"
                    Case 5
                        sName = "Chính Sách Bảo Mật Thông Tin"
                    Case 6
                        sName = "Chính Sách Bảo Hành"
                End Select

                Dim mnu As New MenuItem(sName, ii, "", Core.GenerateURL(sName, ii, "/quy-dinh-chung/"))
                Menu1.FindItem("Quy Định Chung").ChildItems.Add(mnu)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sSearch As String = TextBox1.Text
        If sSearch.Trim <> "" Then
            Response.Redirect("Tim-Kiem.aspx?action=s&k=" & TextBox1.Text)
        End If

    End Sub
End Class