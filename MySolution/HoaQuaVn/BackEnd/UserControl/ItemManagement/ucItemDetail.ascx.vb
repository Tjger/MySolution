Imports Common
Public Class ucItemDetail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCboGroup()
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            Dim sID As String = String.Empty
            If Request.QueryString.Keys.Count > 0 Then
                sID = Request.QueryString("ID").ToString()
                If sID <> "" Then
                    LoadItemInfo(sID)
                End If


            End If
        End If

    End Sub

    Private Sub LoadItemInfo(ByVal sID As String)
        Try
            Dim sSql As String = "SELECT * FROM Item WHERE ItemID =" & Core.SQLStr(sID)
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            If ds.Tables("LoadItemInfo").Rows.Count > 0 Then
                txtItemName.Text = ds.Tables("LoadItemInfo").Rows(0)("ItemName")
                txtDescription.InnerText = ds.Tables("LoadItemInfo").Rows(0)("Description")
                cboGroup.SelectedValue = ds.Tables("LoadItemInfo").Rows(0)("GroupID")
            End If

        Catch ex As Exception

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

        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sItemID As Integer = Core.GetID("ItemID", "Item")
        Dim sHot As String = String.Empty
        If chkHot.Checked Then
            sHot = "1"
        Else
            sHot = "0"
        End If

        Dim sSql As String = String.Format("INSERT INTO Item (ItemID, ItemName, Description,GroupID,Hot) VALUES ({0},{1},{2},{3},{4})", Core.SQLStr(sItemID), Core.SQLStr(txtItemName.Text), Core.SQLStr(txtDescription.Value), Core.SQLStr(cboGroup.SelectedValue), sHot)
        If Var.DBAMain.Execute(sSql) Then
            Response.Redirect("Admin.aspx?module=2")
        End If
    End Sub


    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx?module=2")
    End Sub
End Class