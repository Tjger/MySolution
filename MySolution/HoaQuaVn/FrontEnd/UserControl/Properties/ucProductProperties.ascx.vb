﻿Imports Common
Public Class ucProductProperties
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucProductProperties"
    Public Shared CurrentPage As Integer = 0
    Public Shared TotalPage As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            LoadCombo()

        End If
        
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim PagingDataList As New PagedDataSource()
        Dim ds As New DataSet
        Try
            sSQL = "SELECT * FROM Item WHERE Active='1' ORDER BY CreatedDate DESC"
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")

            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                pagingDataList.DataSource = ds.Tables("LoadCombo").DefaultView()
                pagingDataList.AllowPaging = True
                PagingDataList.PageSize = 6
                pagingDataList.CurrentPageIndex = CurrentPage
                TotalPage = PagingDataList.PageCount
                dtlItemList.DataSource = PagingDataList
                dtlItemList.DataKeyField = "ItemID"
                dtlItemList.DataBind()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

    'Public Property CurrentPage() As Integer
    '    Get
    '        Dim s1 As Object = Me.ViewState("CurrentPage")
    '        If s1 Is Nothing Then
    '            Return 0
    '        Else
    '            Return CInt(s1)
    '        End If
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me.ViewState("CurrentPage") = value
    '    End Set
    'End Property

    Protected Sub lbPrev_Click(sender As Object, e As EventArgs) Handles lblPrev.Click
        Try
            CurrentPage -= 1
            If CurrentPage < 0 Then
                CurrentPage = TotalPage - 1


            End If
            LoadCombo()

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

    Protected Sub lbNext_Click(sender As Object, e As EventArgs) Handles lbNext.Click
        Try
            CurrentPage += 1

            If CurrentPage >= TotalPage Then
                CurrentPage = 0

            End If
            LoadCombo()
        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try

    End Sub
End Class