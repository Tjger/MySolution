Imports Common
Imports System.IO
Public Class ucNewsDetail
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucItemDetail"
    Private Shared sID As String = String.Empty
    Private Shared sMode As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then


                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                If Request.QueryString.Keys.Count > 0 Then
                    sMode = Request.QueryString("m").ToString()
                    Select Case sMode
                        Case 1 'Edit
                            sID = Request.QueryString("ID").ToString()
                            LoadItemInfo(sID)

                        Case Else 'New

                    End Select
                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try


    End Sub

    Private Sub LoadItemInfo(ByVal sID As String)
        Try
            Dim sSql As String = "SELECT * FROM News WHERE AutoID =" & Core.SQLStr(sID)
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            If ds.Tables("LoadItemInfo").Rows.Count > 0 Then
                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Title")) Then
                    txtTitle.Text = ds.Tables("LoadItemInfo").Rows(0)("Title")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Active")) Then
                    chkActive.Checked = ds.Tables("LoadItemInfo").Rows(0)("Active")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("SubContent")) Then
                    txtSubcontent.InnerText = ds.Tables("LoadItemInfo").Rows(0)("SubContent")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("MainContent")) Then
                    txtMaincontent.Text = ds.Tables("LoadItemInfo").Rows(0)("MainContent")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Image")) Then
                    Avatar.ImageUrl = ds.Tables("LoadItemInfo").Rows(0)("Image")
                End If
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Dim sActive As String = String.Empty
            Dim sSql As String = String.Empty
            Dim sDescription As String = ""
            Dim bSaveImage As Boolean = True
            Dim sFileName As String = String.Empty
            If chkActive.Checked Then
                sActive = "1"
            Else
                sActive = "0"
            End If

            If FileUpload1.FileName = "" Then
                bSaveImage = False
            Else
                Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

                'Dim sFileNameThums As String = String.Empty
                sFileName = "~/" & (tempPath & Convert.ToString("Images/News/")) & FileUpload1.FileName
                FileUpload1.SaveAs(getSaveFileNameUpload(FileUpload1.FileName))

            End If

            Select Case sMode
                Case 1

                    If bSaveImage Then
                        sSql = String.Format("UPDATE News SET Title=N{0}, SubContent=N{1}, MainContent=N{2}, Active={3}, DateInput={4}, Image={5} WHERE AutoID={6}" _
              , Core.SQLStr(txtTitle.Text), Core.SQLStr(txtSubcontent.InnerText), Core.SQLStr(txtMaincontent.Text) _
                , Core.SQLStr(sActive), Core.SQLStr(Date.Now), Core.SQLStr(sFileName), Core.SQLStr(sID))
                    Else
                        sSql = String.Format("UPDATE News SET Title=N{0}, SubContent=N{1}, MainContent=N{2}, Active={3}, DateInput={4} WHERE AutoID={5}" _
                                     , Core.SQLStr(txtTitle.Text), Core.SQLStr(txtSubcontent.InnerText), Core.SQLStr(txtMaincontent.Text) _
                                       , Core.SQLStr(sActive), Core.SQLStr(Date.Now), Core.SQLStr(sID))
                    End If
                 
                Case Else
                    sSql = "INSERT INTO News ( Title, SubContent, MainContent, Image, Active, DateInput)"
                    sSql &= String.Format(" VALUES (N{0},N{1},N{2},{3},{4},{5})" _
                                        , Core.SQLStr(txtTitle.Text), Core.SQLStr(txtSubcontent.InnerText), Core.SQLStr(txtMaincontent.Text), Core.SQLStr(sFileName) _
                                          , Core.SQLStr(sActive), Core.SQLStr(Date.Now))

            End Select

            If Var.DBAMain.Execute(sSql) Then
                Response.Redirect("Admin.aspx?module=5")
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try

    End Sub


    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx?module=5")
    End Sub


    Public Function getSaveFileNameUpload(sFileName As String) As String
        Dim FileName As String = String.Empty
        Try
            Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")
            Dim savepath As String = Me.Context.Server.MapPath(tempPath)
            Dim FileNameSave As String = savepath & Convert.ToString("Images\News\")
            FileName = Convert.ToString(savepath & Convert.ToString("Images\News\")) & sFileName
            If Not Directory.Exists(FileNameSave) Then
                Directory.CreateDirectory(FileNameSave)
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "getSaveFileNameUpload", ex.Message)
        End Try
        Return FileName
    End Function

End Class