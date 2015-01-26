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

    Sub InitDataTable(ByRef dt As DataTable)
        Try
            dt.Columns.Add("ID", GetType(String))
            dt.Columns.Add("ItemUrl", GetType(String))
            dt.Columns.Add("ItemName", GetType(String))
            dt.Columns.Add("ItemImageURL", GetType(String))
            dt.Columns.Add("ItemDescription", GetType(String))
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim PagingDataList As New PagedDataSource()
        Dim ds As New DataSet
        Dim iID As Integer = 1
        Dim dt As New DataTable
        Try
            InitDataTable(dt)
            'Item.aspx?action=view&id=
            sSQL = String.Format("SELECT '' AS ID,ItemID, ItemName, ItemImageURL, Description AS ItemDescription, '' AS ItemUrl FROM Item WHERE Active= '1' AND (ItemName Like N{0} OR UnitValue Like {1}) ORDER BY CreatedDate DESC", Core.SQLStr("%" & sKeySearch & "%"), Core.SQLStr("%" & sKeySearch & "%"))
            Var.DBAMain.FillDataset(sSQL, ds, "LoadItem")

            If ds.Tables("LoadItem").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("LoadItem").Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("ID") = iID
                    dr("ItemUrl") = "Item.aspx?action=view&id=" & row("ItemID")
                    dr("ItemName") = row("ItemName")

                    dr("ItemImageURL") = row("ItemImageURL")
                    dr("ItemDescription") = row("ItemDescription")
                    dt.Rows.Add(dr)
                    iID += 1
                Next

            End If

            sSQL = String.Format("SELECT '' AS ID,AutoID AS ItemID, Title AS ItemName,Image AS ItemImageURL, SubContent AS ItemDescription, '' AS ItemUrl FROM News WHERE Active= '1' AND (Title Like N{0} OR KeySearch Like {1}) ", Core.SQLStr("%" & sKeySearch & "%"), Core.SQLStr("%" & sKeySearch & "%"))
            Var.DBAMain.FillDataset(sSQL, ds, "LoadNews")

            If ds.Tables("LoadNews").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("LoadNews").Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("ID") = iID
                    dr("ItemUrl") = "News.aspx?action=view&id=" & row("ItemID")
                    dr("ItemName") = row("ItemName")
                    dr("ItemImageURL") = row("ItemImageURL")
                    dr("ItemDescription") = row("ItemDescription")
                    dt.Rows.Add(dr)
                    iID += 1
                Next

            End If

            PagingDataList.DataSource = dt.DefaultView
            PagingDataList.AllowPaging = True
            PagingDataList.PageSize = 10
            PagingDataList.CurrentPageIndex = CurrentPage
            TotalPage = PagingDataList.PageCount
            dtlItemList.DataSource = PagingDataList
            dtlItemList.DataKeyField = "ID"
            dtlItemList.DataBind()
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