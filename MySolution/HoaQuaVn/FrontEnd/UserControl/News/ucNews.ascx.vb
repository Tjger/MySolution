Imports Common
Public Class ucNews
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucNews"
    Private sID As String = String.Empty
    Public Shared CurrentPage As Integer = 0
    Public Shared TotalPage As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            If Request.QueryString.Count > 0 Then
                sID = Request.QueryString("MyTitleId")


            End If
            LoadCombo()

        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Dim PagingDataList As New PagedDataSource()
        Try
            sSQL = "select AutoID as Id,Title,SubContent as Description,Image fROM News WHERE Active='1' ORDER BY AutoID DESC"
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                PagingDataList.DataSource = ds.Tables("LoadCombo").DefaultView()
                PagingDataList.AllowPaging = True
                PagingDataList.PageSize = 3
                PagingDataList.CurrentPageIndex = CurrentPage
                TotalPage = PagingDataList.PageCount
                dtlComboList.DataSource = PagingDataList
                dtlComboList.DataKeyField = "Id"
                dtlComboList.DataBind()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

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