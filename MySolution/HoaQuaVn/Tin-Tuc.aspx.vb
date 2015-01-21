﻿Imports Common
Public Class List_News
    Inherits System.Web.UI.Page

    Private ClsName = "List_News"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            LoadCombo()

        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
           sSQL = "SELECT * FROM News WHERE Active='1' ORDER BY DateInput DESC"
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                dtlComboList.DataSource = ds.Tables("LoadCombo")
                dtlComboList.DataBind()
            End If



        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

End Class