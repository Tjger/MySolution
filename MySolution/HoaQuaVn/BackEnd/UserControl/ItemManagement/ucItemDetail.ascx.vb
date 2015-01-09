Imports Common
Imports System.IO

Public Class ucItemDetail
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucItemDetail"
    Private Shared sID As String = String.Empty
    Private Shared sMode As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                LoadCboGroup()
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
            Dim sSql As String = "SELECT * FROM Item WHERE ItemID =" & Core.SQLStr(sID)
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            If ds.Tables("LoadItemInfo").Rows.Count > 0 Then
                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ItemName")) Then
                    txtItemName.Text = ds.Tables("LoadItemInfo").Rows(0)("ItemName")
                End If

                'If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Description")) Then
                '    txtDescription.Text = ds.Tables("LoadItemInfo").Rows(0)("Description")
                'End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("GroupID")) Then
                    cboGroup.SelectedValue = ds.Tables("LoadItemInfo").Rows(0)("GroupID")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Active")) Then
                    chkActive.Checked = ds.Tables("LoadItemInfo").Rows(0)("Active")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Hot")) Then
                    chkHot.Checked = ds.Tables("LoadItemInfo").Rows(0)("Hot")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ItemPrice")) Then
                    txtItemPrice.Text = ds.Tables("LoadItemInfo").Rows(0)("ItemPrice")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("FromWhere")) Then
                    txtFromWhere.Text = ds.Tables("LoadItemInfo").Rows(0)("FromWhere")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("UnitValue")) Then
                    txtUnitValue.Text = ds.Tables("LoadItemInfo").Rows(0)("UnitValue")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("AdultVitamin")) Then
                    txtAdultVitamin.Text = ds.Tables("LoadItemInfo").Rows(0)("AdultVitamin")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("AdultEnergy")) Then
                    txtAdultEnergy.Text = ds.Tables("LoadItemInfo").Rows(0)("AdultEnergy")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ChildVitamin")) Then
                    txtChildVitamin.Text = ds.Tables("LoadItemInfo").Rows(0)("ChildVitamin")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ChildEnergy")) Then
                    txtChildEnergy.Text = ds.Tables("LoadItemInfo").Rows(0)("ChildEnergy")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ElementInfo")) Then
                    txtVitaminElement.Text = ds.Tables("LoadItemInfo").Rows(0)("ElementInfo")
                End If

                If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ItemImageURL")) Then
                    Avatar.ImageUrl = ds.Tables("LoadItemInfo").Rows(0)("ItemImageURL")
                End If
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub
    Private Sub LoadCboGroup()
        Try
            Dim sSql As String = "SELECT * FROM ItemGroup"
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadCboGroup")
            cboGroup.DataSource = ds.Tables("LoadCboGroup")

            cboGroup.DataTextField = "GroupName"
            cboGroup.DataValueField = "GroupID"
            cboGroup.DataBind()
        Catch ex As Exception
            Log.LogError(ClsName, "LoadCboGroup", ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim sItemID As Integer = Core.GetID("ItemID", "Item")
            Dim sActive As String = String.Empty
            Dim sSql As String = String.Empty
            Dim sHot As String = String.Empty
            Dim sDescription As String = ""
            Dim bSaveImage As Boolean = True
            Dim sFileName As String = String.Empty
            If chkActive.Checked Then
                sActive = "1"
            Else
                sActive = "0"
            End If

            If chkHot.Checked Then
                sHot = "1"
            Else
                sHot = "0"
            End If
            If FileUpload1.FileName = "" Then
                bSaveImage = False
            Else
                Dim tempPath As String = System.Configuration.ConfigurationManager.AppSettings("FolderPath")

                'Dim sFileNameThums As String = String.Empty
                sFileName = "~/" & (tempPath & Convert.ToString("Images/")) & FileUpload1.FileName
                FileUpload1.SaveAs(getSaveFileNameUpload(FileUpload1.FileName))

            End If

           

            Select Case sMode
                Case 1

                    sItemID = sID
                    If bSaveImage Then
                        sSql = String.Format("UPDATE Item SET ItemName=N{0}, Description=N{1}, GroupID={2}, ItemPrice=N{3}, Active={4}, FromWhere=N{5}, UnitValue=N{6}, Hot={7}, AdultVitamin={8}, AdultEnergy={9}, ChildVitamin={10}, ChildEnergy={11},ElementInfo=N{12},ItemImageURL={13} WHERE ItemID={14}" _
                                       , Core.SQLStr(txtItemName.Text), Core.SQLStr(sDescription), Core.SQLStr(cboGroup.SelectedValue), Core.SQLStr(txtItemPrice.Text) _
                                         , Core.SQLStr(sActive), Core.SQLStr(txtFromWhere.Text), Core.SQLStr(txtUnitValue.Text), Core.SQLStr(sHot) _
                                         , Core.SQLStr(txtAdultVitamin.Text), Core.SQLStr(txtAdultEnergy.Text), Core.SQLStr(txtChildVitamin.Text), Core.SQLStr(txtChildEnergy.Text) _
                                         , Core.SQLStr(txtVitaminElement.Text), Core.SQLStr(sFileName), Core.SQLStr(sItemID))
                    Else
                        sSql = String.Format("UPDATE Item SET ItemName=N{0}, Description=N{1}, GroupID={2}, ItemPrice=N{3}, Active={4}, FromWhere=N{5}, UnitValue=N{6}, Hot={7}, AdultVitamin={8}, AdultEnergy={9}, ChildVitamin={10}, ChildEnergy={11},ElementInfo=N{12} WHERE ItemID={13}" _
                                       , Core.SQLStr(txtItemName.Text), Core.SQLStr(sDescription), Core.SQLStr(cboGroup.SelectedValue), Core.SQLStr(txtItemPrice.Text) _
                                         , Core.SQLStr(sActive), Core.SQLStr(txtFromWhere.Text), Core.SQLStr(txtUnitValue.Text), Core.SQLStr(sHot) _
                                         , Core.SQLStr(txtAdultVitamin.Text), Core.SQLStr(txtAdultEnergy.Text), Core.SQLStr(txtChildVitamin.Text), Core.SQLStr(txtChildEnergy.Text) _
                                         , Core.SQLStr(txtVitaminElement.Text), Core.SQLStr(sItemID))
                    End If

                   
                Case Else
                    sSql = "INSERT INTO Item ( ItemName, Description, GroupID, ItemPrice, Active, FromWhere, UnitValue, Hot, AdultVitamin, AdultEnergy, ChildVitamin, ChildEnergy, ElementInfo,ItemImageURL)"
                    sSql &= String.Format(" VALUES (N{0},N{1},{2},N{3},{4},N{5},N{6},{7},{8},{9},{10},{11},N{12},{13})" _
                                        , Core.SQLStr(txtItemName.Text), Core.SQLStr(sDescription), Core.SQLStr(cboGroup.SelectedValue), Core.SQLStr(txtItemPrice.Text) _
                                          , Core.SQLStr(sActive), Core.SQLStr(txtFromWhere.Text), Core.SQLStr(txtUnitValue.Text), Core.SQLStr(sHot) _
                                          , Core.SQLStr(txtAdultVitamin.Text), Core.SQLStr(txtAdultEnergy.Text), Core.SQLStr(txtChildVitamin.Text), Core.SQLStr(txtChildEnergy.Text) _
                                          , Core.SQLStr(txtVitaminElement.Text), Core.SQLStr(sFileName))

            End Select

            If Var.DBAMain.Execute(sSql) Then
                Response.Redirect("Admin.aspx?module=2")
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try

    End Sub


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


    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

End Class