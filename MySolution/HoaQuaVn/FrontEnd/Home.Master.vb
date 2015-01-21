﻿Imports Common
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

                'lblShowRegisterLogo.Value = 1
                'lblRegisterUrl.Value = "http://www.moit.gov.vn/vn/Pages/Trangchu.aspx"
            End If

            

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub


    Sub GetMenu()
        Try
            Dim sSQL As String = String.Empty
            Dim ds As New DataSet
            Dim dt As New DataTable
            sSQL = "SELECT * FROM ItemGroup"
            Var.DBAMain.FillDataset(sSQL, ds, "Menu")
            dt = ds.Tables("Menu")
            Dim dr() As DataRow = dt.Select("ParentID = -1")
            For Each row As DataRow In dr
                Dim mn As New MenuItem(row("GroupName"), row("GroupID"), "", "")
                Menu1.FindItem("Products").ChildItems.Add(mn)
            Next
            '        For Each item As DataRow In dr

            '            Dim mn As New MenuItem(item("GroupName").ToString(), item("GroupID").ToString(), "", "")
            '            Menu1.FindItem(item("ParentID").ToString()).ChildItems.Add(mn)

            '        Next

            '         foreach (DataRow dr in drowpar)
            '{
            '    menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(), 
            '            dr["MenuID"].ToString(), "", 
            '            dr["MenuLocation"].ToString()));
            '}

            'foreach (DataRow dr in dt.Select("ParentID >" + 0))
            '{
            '    MednuItem mnu = new MenuItem(dr["MenuName"].ToString(), 
            '                   dr["MenuID"].ToString(), 
            '                   "", dr["MenuLocation"].ToString());
            '    menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
            '}





        Catch ex As Exception

        End Try
    End Sub
End Class