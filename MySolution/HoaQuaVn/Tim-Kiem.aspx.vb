Imports Common
Public Class Tim_Kiem
    Inherits System.Web.UI.Page
    Private Shared CurrentPage As Integer = 0
    Private Shared TotalPage As Integer = 1
    Private Shared sKeySearch As String = ""
    Private ClsName = "List_News"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)

            If Request.QueryString.Count > 0 Then
                sKeySearch = Request.QueryString("k")


            End If
            LoadCombo()
        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim PagingDataList As New PagedDataSource()
        Dim ds As New DataSet
        Try
            sSQL = String.Format("SELECT * FROM Item WHERE Active= '1' AND (ItemName Like N{0} OR UnitValue LIke {1}) ORDER BY CreatedDate DESC", Core.SQLStr("%" & sKeySearch & "%"), Core.SQLStr("%" & sKeySearch & "%"))
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")

            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                PagingDataList.DataSource = ds.Tables("LoadCombo").DefaultView()
                PagingDataList.AllowPaging = True
                PagingDataList.PageSize = 10
                PagingDataList.CurrentPageIndex = CurrentPage
                TotalPage = PagingDataList.PageCount
                dtlItemList.DataSource = PagingDataList
                dtlItemList.DataKeyField = "ItemID"
                dtlItemList.DataBind()
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