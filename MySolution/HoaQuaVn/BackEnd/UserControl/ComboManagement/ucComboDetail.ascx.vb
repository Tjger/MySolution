Imports Common
Public Class ucComboDetail
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucComboDetail"
    Private Shared sID As String = String.Empty
    Private dtComboItem As DataTable
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
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
       
    End Sub

    Private Sub LoadItemInfo(ByVal sID As String)
        Try
            If sID <> "" Then
                Dim sSql As String = "SELECT * FROM Combo WHERE ComboID =" & Core.SQLStr(sID)
                Dim ds As New DataSet
                Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
                If ds.Tables("LoadItemInfo").Rows.Count > 0 Then
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ComboName")) Then
                        txtItemName.Text = ds.Tables("LoadItemInfo").Rows(0)("ComboName")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Description")) Then
                        txtSubcontent.InnerText = ds.Tables("LoadItemInfo").Rows(0)("Description")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Active")) Then
                        chkActive.Checked = ds.Tables("LoadItemInfo").Rows(0)("Active")
                    Else
                        chkActive.Checked = False
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ComboPrice")) Then
                        txtItemPrice.Text = ds.Tables("LoadItemInfo").Rows(0)("ComboPrice")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("ItemList")) Then
                        txtItemList.Text = ds.Tables("LoadItemInfo").Rows(0)("ItemList")
                    End If
                End If
                'sSql = "SELECT * FROM ComboItem WHERE ComboID =" & Core.SQLStr(sID)

                'Var.DBAMain.FillDataset(sSql, ds, "LoadComboItem")
                'dtComboItem = ds.Tables("LoadComboItem")
            End If
          
        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub



    'Private Sub LoadItemList()
    '    Try
    '        Dim sSql As String = "SELECT ItemID,ItemName FROM Item WHERE Active='1'"
    '        Dim ds As New DataSet
    '        Var.DBAMain.FillDataset(sSql, ds, "LoadItemList")
    '        chkItemList.DataSource = ds

    '        chkItemList.DataTextField = "ItemName"

    '        chkItemList.DataValueField = "ItemID"

    '        chkItemList.DataBind()

    '        If Core.IsDBNullOrStringEmpty(dtComboItem) = False Then

    '            If dtComboItem.Rows.Count > 0 Then
    '                For Each li As ListItem In chkItemList.Items
    '                    Dim dr() As DataRow = dtComboItem.Select("ItemID=" & Core.SQLStr(li.Value))
    '                    If dr.Count > 0 Then
    '                        li.Selected = True
    '                    End If

    '                Next
    '            End If

    '        End If



    '    Catch ex As Exception
    '        Log.LogError(ClsName, "LoadItemList", ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim sItemID As Integer = Core.GetID("ComboID", "Combo")
            Dim sActive As String = String.Empty
            Dim sSql As String = String.Empty
            If chkActive.Checked Then
                sActive = "1"
            Else
                sActive = "0"
            End If
            Select Case sMode
                Case 1
                    sItemID = sID
                    sSql = String.Format("UPDATE Combo SET ComboName=N{0},ComboPrice=N{1}, Description=N{2},Active={3}, ItemList= N{4} WHERE ComboID={5}", Core.SQLStr(txtItemName.Text), Core.SQLStr(txtItemPrice.Text), Core.SQLStr(txtSubcontent.InnerText), Core.SQLStr(sActive), Core.SQLStr(txtItemList.Text), Core.SQLStr(sItemID))
                Case Else

                    sSql = String.Format("INSERT INTO Combo (ComboID, ComboName,ComboPrice, Description,Active,ItemList) VALUES (N{0},N{1},N{2},N{3},{4},N{5})", Core.SQLStr(sItemID), Core.SQLStr(txtItemName.Text), Core.SQLStr(txtItemPrice.Text), Core.SQLStr(txtSubcontent.InnerText), Core.SQLStr(sActive), Core.SQLStr(txtItemList.Text))

            End Select
            If Var.DBAMain.Execute(sSql) Then

                Response.Redirect("Admin.aspx?module=3")
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try
       

    End Sub


    'Private Sub AddComboItem()
    '    Try
    '        Dim sSql As String = "SELECT * FROM ComboItem WHERE ComboID =" & Core.SQLStr(sID)
    '        Dim ds As New DataSet
    '        Var.DBAMain.FillDataset(sSql, ds, "DeleteOldItem")

    '        If ds.Tables("DeleteOldItem").Rows.Count > 0 Then
    '            sSql = "DELETE FROM ComboItem WHERE ComboID =" & Core.SQLStr(sID)
    '            Var.DBAMain.Execute(sSql)
    '        End If

    '        For Each li As ListItem In chkItemList.Items
    '            If li.Selected Then
    '                sSql = String.Format("INSERT INTO ComboItem (ComboID,ItemID) VALUES ({0},{1})", Core.SQLStr(sID), Core.SQLStr(li.Value))
    '                Var.DBAMain.Execute(sSql)
    '            End If
    '        Next



    '    Catch ex As Exception
    '        Log.LogError(ClsName, "AddComboItem", ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx?module=3")
    End Sub
End Class