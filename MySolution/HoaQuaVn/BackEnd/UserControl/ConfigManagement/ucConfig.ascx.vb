Imports Common
Imports System.IO

Public Class ucConfig
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucConfig"
    Private Shared sMode As String = String.Empty

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
            sSql = "SELECT * FROM SysPara "
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
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
                            chkShowRegisterLogo.Checked = row("ItemID")
                        Case "RegisterLogoURL"
                            txtRegisterUrl.Text = row("ItemID")
                        Case "Email"
                            txtEmails.Text = row("ItemID")
                        Case "Skype"
                            txtSkype.Text = row("ItemID")
                        Case "Yahoo"
                            txtYahoo.Text = row("ItemID")
                        Case "Facebook"
                            txtFacebook.Text = row("ItemID")
                        Case "GooglePlus"
                            txtGoogle.Text = row("ItemID")
                        Case "Introduce"
                            txtIntroduce.Text = row("ItemID")
                        Case "Contacts"
                            txtContact.Text = row("ItemID")
                       
                    End Select

                End If
            Next

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim sSql As String = String.Empty
            Dim bSaveImage1 As Boolean = True
            Dim bSaveImage2 As Boolean = True
            Dim bSaveImage3 As Boolean = True
            Dim sFileName1 As String = String.Empty
            Dim sFileName2 As String = String.Empty
            Dim sFileName3 As String = String.Empty

            If FileUpload1.FileName = "" Then
                bSaveImage1 = False
            Else
                Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

                'Dim sFileNameThums As String = String.Empty
                sFileName1 = "~/" & (tempPath & Convert.ToString("Images/")) & FileUpload1.FileName
                FileUpload1.SaveAs(getSaveFileNameUpload(FileUpload1.FileName))

            End If

            If FileUpload2.FileName = "" Then
                bSaveImage2 = False
            Else
                Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

                'Dim sFileNameThums As String = String.Empty
                sFileName2 = "~/" & (tempPath & Convert.ToString("Images/")) & FileUpload2.FileName
                FileUpload2.SaveAs(getSaveFileNameUpload(FileUpload2.FileName))

            End If

            If FileUpload3.FileName = "" Then
                bSaveImage3 = False
            Else
                Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

                'Dim sFileNameThums As String = String.Empty
                sFileName3 = "~/" & (tempPath & Convert.ToString("Images/")) & FileUpload3.FileName
                FileUpload3.SaveAs(getSaveFileNameUpload(FileUpload3.FileName))

            End If
            If bSaveImage1 Then
                SaveDB("ImageURL1", sFileName1)
            End If

            If bSaveImage2 Then
                SaveDB("ImageURL2", sFileName2)
            End If

            If bSaveImage3 Then
                SaveDB("ImageURL3", sFileName3)
            End If

            SaveDB("TextInRed1", txtInRed1.Text)
            SaveDB("TextInRed2", txtInRed2.Text)
            SaveDB("TextInRed3", txtInRed3.Text)
            SaveDB("TextInWhite1", txtInWhite1.Text)
            SaveDB("TextInWhite2", txtInWhite2.Text)
            SaveDB("TextInWhite3", txtInWhite3.Text)
          
            SaveDB("ShowRegisterLogo", chkShowRegisterLogo.Checked)
            SaveDB("RegisterLogoURL", txtRegisterUrl.Text)

            SaveDB("Email", txtEmails.Text)
            SaveDB("Skype", txtSkype.Text)
            SaveDB("Yahoo", txtYahoo.Text)
            SaveDB("Facebook", txtFacebook.Text)
            SaveDB("GooglePlus", txtGoogle.Text)

            SaveDB("Introduce", txtIntroduce.Text)
            SaveDB("Contacts", txtContact.Text)

            Response.Redirect("Admin.aspx")
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try

    End Sub

    Private Function SaveDB(ByVal sKey As String, ByVal sValue As String)
        Dim bFlag As Boolean = False
        Try
            Dim ds As New DataSet
            Dim sSql As String = String.Format("SELECT * FROM SysPara WHERE ComboID={0}", Core.SQLStr(sKey))
            Var.DBAMain.FillDataset(sSql, ds, "SaveDB")
            If ds.Tables("SaveDB").Rows.Count > 0 Then
                sSql = String.Format("UPDATE SysPara SET ItemID =N{0} WHERE ComboID={1}", Core.SQLStr(sValue), Core.SQLStr(sKey))
            Else
                sSql = String.Format("INSERT INTO SysPara (ComboID, ItemID) VALUES(N{0}, N{1})", Core.SQLStr(sKey), Core.SQLStr(sValue))
            End If
            bFlag = Var.DBAMain.Execute(sSql)
        Catch ex As Exception
            Log.LogError(ClsName, "SaveDB", ex.Message)
        End Try
        Return bFlag
    End Function

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx?module=2")
    End Sub


    Public Function getSaveFileNameUpload(sFileName As String) As String
        Dim FileName As String = String.Empty
        Try
            Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")
            Dim savepath As String = Me.Context.Server.MapPath(tempPath)
            Dim FileNameSave As String = savepath & Convert.ToString("Images\")
            FileName = Convert.ToString(savepath & Convert.ToString("Images\")) & sFileName
            If Not Directory.Exists(FileNameSave) Then
                Directory.CreateDirectory(FileNameSave)
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "getSaveFileNameUpload", ex.Message)
        End Try
        Return FileName
    End Function


End Class