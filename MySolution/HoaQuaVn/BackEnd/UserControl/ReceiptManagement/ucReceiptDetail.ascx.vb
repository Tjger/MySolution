﻿Imports Common
Public Class ucReceiptDetail
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucReceiptDetail"
    Private Shared sID As String = String.Empty
    Private dtComboItem As DataTable
    Private Shared sMode As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                LoadCboGroup()
                If Request.QueryString.Keys.Count > 0 Then
                    sID = Request.QueryString("ID").ToString()
                    LoadItemInfo(sID)



                End If
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Private Sub LoadItemInfo(ByVal sID As String)
        Try
            If sID <> "" Then
                Dim sSql As String = "SELECT * FROM Receipt WHERE Status='1' AND ReceiptNo =" & Core.SQLStr(sID)
                Dim ds As New DataSet
                Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
                If ds.Tables("LoadItemInfo").Rows.Count > 0 Then
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("GuestName")) Then
                        txtName.Text = ds.Tables("LoadItemInfo").Rows(0)("GuestName")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Message")) Then
                        txtSubcontent.InnerText = ds.Tables("LoadItemInfo").Rows(0)("Message")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("GuestMobile")) Then
                        txtMobile.Text = ds.Tables("LoadItemInfo").Rows(0)("GuestMobile")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("GuestEmail")) Then
                        txtEmail.Text = ds.Tables("LoadItemInfo").Rows(0)("GuestEmail")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("GuestAddress")) Then
                        txtAddress.Text = ds.Tables("LoadItemInfo").Rows(0)("GuestAddress")
                    End If
                    If Not Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo").Rows(0)("Status")) Then
                        cboStatus.SelectedValue = ds.Tables("LoadItemInfo").Rows(0)("Status")
                    End If

                End If
                
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

    Private Sub LoadCboGroup()
        Try
            Dim sSql As String = "SELECT * FROM ReceiptStatus"
            Dim ds As New DataSet
            Var.DBAMain.FillDataset(sSql, ds, "LoadCboGroup")
            cboStatus.DataSource = ds.Tables("LoadCboGroup")

            cboStatus.DataTextField = "StatusName"
            cboStatus.DataValueField = "StatusID"
            cboStatus.DataBind()
        Catch ex As Exception
            Log.LogError(ClsName, "LoadCboGroup", ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Dim sActive As String = String.Empty
            Dim sSql As String = String.Empty
           
            sSql = String.Format("UPDATE Receipt SET Status={0} WHERE ReceiptNo={1}", Core.SQLStr(cboStatus.SelectedValue), Core.SQLStr(sID))
            If Var.DBAMain.Execute(sSql) Then

                Response.Redirect("Admin.aspx")
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try


    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx")
    End Sub

End Class